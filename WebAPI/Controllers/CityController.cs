using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;
//using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly DataContext dc;
        public CityController(DataContext dc)
        {
            this.dc = dc;
        }

        // get api/city
        [HttpGet("")]
        public async Task<IActionResult> GetCities()
        {
            var cities = await dc.Cities.ToListAsync();

            return Ok(cities);
        }
        
        /* 
            3 ways to add an object:

            1. Pass the info in querystring
            2. Pass the info in URL
            3. Pass the info in the body as JSON 
        */
        
        // post api/city/add?cityname=Miami
        // post api/city/add/Los Angeles
        [HttpPost("add")]
        [HttpPost("add/{cityname}")]
        public async Task<IActionResult> AddCity(string cityName)
        {
            City city = new City();
            city.Name = cityName;
            
            await dc.Cities.AddAsync(city);
            await dc.SaveChangesAsync();

            return Ok(city);
        }        
        
        // post api/city/post
        [HttpPost("post")]
        public async Task<IActionResult> AddCity(City city)
        {
            
            await dc.Cities.AddAsync(city);
            await dc.SaveChangesAsync();

            return Ok(city);
        }

        // delete api/city/delete/10
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            var city = await dc.Cities.FindAsync(id);
            dc.Cities.Remove(city);
            await dc.SaveChangesAsync();

            return Ok(id);
        }        
    }
}
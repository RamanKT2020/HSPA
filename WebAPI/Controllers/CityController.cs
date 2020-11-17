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
        
        
        // post api/city/add?cityname=Miami
        [HttpPost("add")]
        public async Task<IActionResult> AddCity(string cityName)
        {
            City city = new City();
            city.Name = cityName;
            
            await dc.Cities.AddAsync(city);
            await dc.SaveChangesAsync();

            return Ok(city);
        }
    }
}
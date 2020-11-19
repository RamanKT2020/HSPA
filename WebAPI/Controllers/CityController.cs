using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data.Repo;
using WebAPI.Models;
//using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityRepository repo;

        public CityController(ICityRepository repo)
        {
            this.repo = repo;
        }

        // get api/city
        [HttpGet("")]
        public async Task<IActionResult> GetCities()
        {
            var cities = await repo.GetCitiesAsync();

            return Ok(cities);
        }
        
        /* 
            3 ways to add an object:

            1. Pass the info in querystring
            2. Pass the info in URL
            3. Pass the info in the body as JSON 
        */
        //commented out 1 and 2 types because we only need one way to add a city, type 3

        // post api/city/add?cityname=Miami
        // post api/city/add/Los Angeles
        // [HttpPost("add")]
        // [HttpPost("add/{cityname}")]
        // public async Task<IActionResult> AddCity(string cityName)
        // {
        //     City city = new City();
        //     city.Name = cityName;
            
        //     repo.AddCity(city);

        //     return Ok(city);
        // }        
        
        // post api/city/post
        [HttpPost("post")]
        public async Task<IActionResult> AddCity(City city)
        {
            repo.AddCity(city);
            await repo.SaveAsync();
            return StatusCode(201);
        }

        // delete api/city/delete/10
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            repo.DeleteCity(id);
            await repo.SaveAsync();
            return Ok(id);
        }        
    }
}
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data.Dtos;
using WebAPI.Interfaces;
using WebAPI.Models;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IUnitOfWork uow;

        public CityController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        // get api/city
        [HttpGet("")]
        public async Task<IActionResult> GetCities()
        {
            var cities = await uow.CityRepository.GetCitiesAsync();

            var citiesDto = from c in cities
                            select new CityDto()
            {
                Id = c.Id,
                Name = c.Name    
            };

            return Ok(citiesDto);
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
            
        //     uow.CityRepository.AddCity(city);

        //     return Ok(city);
        // }        
        
        // post api/city/post
        [HttpPost("post")]
        public async Task<IActionResult> AddCity(CityDto cityDto)
        {
            var city = new City {
                Name = cityDto.Name,
                LastUpdatedBy = 1,
                LastUpdatedOn = DateTime.Now
            };

            uow.CityRepository.AddCity(city);
            await uow.SaveAsync();

            return StatusCode(201);
        }

        // delete api/city/delete/10
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            uow.CityRepository.DeleteCity(id);
            await uow.SaveAsync();
            return Ok(id);
        }        
    }
}
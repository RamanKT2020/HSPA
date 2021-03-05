using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data.Dtos;
using WebAPI.Interfaces;
using WebAPI.Models;

/*
    A couple of issues with this controller:

    1. It doesn't use plurality in URLs "GET api/city" instead of "GET api/Cities"
    2. The URLs have api/city/post for adding a city. "post" in the URL is redundant as you would be making a POST request to add
*/
namespace WebAPI.Controllers
{
    public class CityController : BaseController
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public CityController(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        // get api/city
        [HttpGet("")]
        public async Task<IActionResult> GetCities()
        {
            //throw new UnauthorizedAccessException();

            var cities = await uow.CityRepository.GetCitiesAsync();
            var citiesDto = mapper.Map<IEnumerable<CityDto>>(cities);
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
            var city = mapper.Map<City>(cityDto);
            city.LastUpdatedBy = 1;
            city.LastUpdatedOn = DateTime.Now;
            uow.CityRepository.AddCity(city);
            await uow.SaveAsync();
            return StatusCode(201);
        }

        
        // post api/city/update
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateCity(int id, CityDto cityDto)
        {
            //Show minimal information to a potential hacker
            if (id != cityDto.Id)
                return BadRequest("Update not allowed.");

            var cityFromDb = await uow.CityRepository.FindCity(id);

            //Show minimal information to a potential hacker
            if (cityFromDb == null)
                return BadRequest("Update not allowed.");

            cityFromDb.LastUpdatedBy = 1;
            cityFromDb.LastUpdatedOn = DateTime.Now;
            mapper.Map(cityDto, cityFromDb);

            throw new Exception("Some unknown error occured.");

            await uow.SaveAsync();
            return StatusCode(200);
        }

        [HttpPut("updateCityName/{id}")]
        public async Task<IActionResult> UpdateCity(int id, CityUpdateDto cityUpdateDto)
        {
            var cityFromDb = await uow.CityRepository.FindCity(id);
            cityFromDb.LastUpdatedBy = 1;
            cityFromDb.LastUpdatedOn = DateTime.Now;
            mapper.Map(cityUpdateDto, cityFromDb);
            await uow.SaveAsync();
            return StatusCode(200);
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        public CityController()
        {
        }

        // get api/city
        [HttpGet("")]
        public IEnumerable<string> Getstrings()
        {
            return new string[] {"Atlanta", "New York", "Chicago"};
        }


    }
}
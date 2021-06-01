using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLibrary.Data;
using DataLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BirdController : ControllerBase
    {
        private readonly IBirdData _birdData;

        public BirdController(IBirdData birdData)
        {
            _birdData = birdData;
        }

        [HttpGet]
        public async Task<List<BirdModel>> Get()
        {
            return await _birdData.GetBirds();
        }
    }
}
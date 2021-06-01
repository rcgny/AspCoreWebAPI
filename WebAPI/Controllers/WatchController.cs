using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLibrary.Models;
using DataLibrary.Data; 
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WatchController : ControllerBase
    {
        private readonly IBirdData _birdData;
        private readonly IWatchData _watchData;

        public WatchController(IBirdData birdData, IWatchData watchData)
        {
            _birdData = birdData;
            _watchData = watchData;
        }

        [HttpPost]
        [ValidateModel]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(WatchModel watch)
        {
            var birds = await _birdData.GetBirds();

            watch.Category = birds.Where(x => x.Id == watch.BirdId).First().Name;

            int id = await _watchData.CreateWatch(watch);

            return Ok(new { Id = id });
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var watch = await _watchData.GetWatchById(id);

            if (watch != null)
            {
                var birds = await _birdData.GetBirds();

                var output = new
                {
                    Watch = watch,
                    Bird = birds.Where(x => x.Id == watch.BirdId).FirstOrDefault()?.Name
                };

                return Ok(output);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put([FromBody]WatchUpdateModel data)
        {
            // OrderUpdateModel Id/OrderName needs to be filled out first by UI or other
            //rcgtemp - test
            //data.Id = 2002;
            //data.Location = "bird Feeder";
           

            await _watchData.UpdateLocation(data.Id, data.Location);
            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            await _watchData.DeleteWatch(id);

            return Ok();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment2.Data;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Assignment2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdultsController : ControllerBase
    {
        private IAdultService adultsService;

        public AdultsController(IAdultService adultsService)
        {
            this.adultsService = adultsService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Adult>>>
            GetAdults([FromQuery] string? lastname)
        {
            try
            {
                IList<Adult> adults = await adultsService.GetAdultsAsync();
                if (lastname != null)
                {
                    adults = adults.Where(adult => adult.LastName == lastname).ToList();
                }
                return Ok(adults);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpDelete]
        [Route("{Id:int}")]
        public async Task<ActionResult> DeleteAdult([FromRoute] int Id) {
            try {
                await adultsService.RemoveAdultAsync(Id);
                return Ok();
            } catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Adult>> AddAdult([FromBody] Adult adult) {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try {
                Adult added = await adultsService.AddAdultAsync(adult);
                return Created($"/{added.Id}",added);
            } catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPatch]
        [Route("{Id:int}")]
        public async Task<ActionResult<Adult>> UpdateAdult([FromBody] Adult adult) {
            try {
                Adult updatedAdult = await adultsService.UpdateAsync(adult);
                return Ok(updatedAdult); 
            } catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}
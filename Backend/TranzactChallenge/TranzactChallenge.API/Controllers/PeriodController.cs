using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TranzactChallenge.Application.Services;

namespace TranzactChallenge.API.Controllers
{
    [Route("api/period")]
    [EnableCors("permit")]
    public class PeriodController : ControllerBase
    {
        private readonly IPeriodService _periodService;
        public PeriodController(IPeriodService periodService)
        {
            _periodService = periodService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {     
            try
            {
                var periods = await _periodService.GetPeriodsAll();

                return Ok(periods);
            }
            catch (Exception)
            {
                return StatusCode(500, "Something went wrong, internal Server Error");
            }
        }
    }
}

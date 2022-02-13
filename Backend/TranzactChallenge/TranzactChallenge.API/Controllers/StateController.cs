using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TranzactChallenge.Application.Services;
using TranzactChallenge.Core.Entities;

namespace TranzactChallenge.API.Controllers
{
    [Route("api/state")]
    [EnableCors("permit")]
    public class StateController : ControllerBase
    {
        private readonly IStateService _stateService;
        public StateController(IStateService stateService)
        {
            _stateService = stateService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            
            try
            {
                var states = await _stateService.GetStatesAll();

                return Ok(states);
            }
            catch (Exception)
            {
                return StatusCode(500, "Something went wrong, internal Server Error");
            }
        }
    }
}

using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TranzactChallenge.Application.Services;
using TranzactChallenge.Core.Entities;

namespace TranzactChallenge.API.Controllers
{
    [Route("api/premium")]
    [EnableCors("permit")]
    public class PremiumController : ControllerBase
    {
        private readonly IPremiumService _premiumService;
        public PremiumController(IPremiumService premiumService)
        {
            _premiumService = premiumService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPremiums(PostFilter filter)
        {
            try
            {
                var unidades = await _premiumService.GetPremiums(filter);

                return Ok(unidades);
            }
            catch (Exception)
            {
                return StatusCode(500, "Something went wrong, internal Server Error");
            }            
        }
    }
}

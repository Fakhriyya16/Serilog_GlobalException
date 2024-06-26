using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;

namespace App_API.Controllers.UI
{
    public class CityController : BaseController
    {
        private readonly ICityService _cityService;
        private readonly ILogger<CityController> _logger;
        public CityController(ICityService cityService, ILogger<CityController> logger)
        {
            _cityService = cityService;
            _logger = logger;

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("Get All is working");
            return Ok(await _cityService.GetAll());
        }


    }
}

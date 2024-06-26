using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;

namespace App_API.Controllers.UI
{
    public class CountryController : BaseController
    {
        private readonly ICountryService _countryService;
        private readonly ILogger<CountryController> _logger;    
        public CountryController(ICountryService countryService, ILogger<CountryController> logger)
        {
            _countryService = countryService;
            _logger = logger;

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("Get All is working");
            return Ok(await _countryService.GetAllAsync());
        }
    }
}

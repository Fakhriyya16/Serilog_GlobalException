using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Cities;
using Service.Services.Interfaces;

namespace App_API.Controllers.Admin
{
    public class CityController : BaseAdminController
    {
        private readonly ICityService _cityService;
        private readonly ILogger<CityController> _logger;
        public CityController(ICityService cityService, ILogger<CityController> logger)
        {
            _cityService = cityService;
            _logger = logger;

        }

        [HttpGet("{id}")]
        public IActionResult Detail([FromRoute] int id)
        {
            return Ok(_cityService.GetById(id));
        }

        [HttpGet]
        public IActionResult GetByName([FromQuery] string name)
        {
            if (name is null) throw new ArgumentNullException();

            return Ok(_cityService.GetByName(name));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CityCreateDto request)
        {
            if (!ModelState.IsValid) return BadRequest();
            await _cityService.CreateAsync(request);
            return Ok();
        }
    }
}

using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Countries;
using Service.Services.Interfaces;

namespace App_API.Controllers.Admin
{
    public class CountryController : BaseAdminController
    {
        private readonly ICountryService _countryService;
        private readonly IMapper _mapper;
        public CountryController(ICountryService countryService,IMapper mapper)
        {
            _countryService = countryService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(_mapper.Map<CountryDetailDto>(await _countryService.GetById(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CountryCreateDto request)
        {
            await _countryService.CreateAsync(request);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id,[FromBody] CountryEditDto request)
        {
            var country = await _countryService.GetById(id);

            if (country is null) return NotFound();

            await _countryService.EditAsync(country, request);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _countryService.DeleteAsync(id);
            return Ok();
        }
    }
}

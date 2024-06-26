using AutoMapper;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using Repository.Repositories.Interfaces;
using Service.DTOs.Cities;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CityService> _logger;
        public CityService(ICityRepository cityRepository,IMapper mapper, ICountryRepository countryRepository,ILogger<CityService> logger)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
            _countryRepository = countryRepository;
            _logger = logger;
        }

        public async Task CreateAsync(CityCreateDto model)
        {
            var country = await _countryRepository.GetByIdAsync(model.CountryId);
            if (country == null)
            {
                _logger.LogWarning("Country is not found");
                throw new NotFoundException("Data not found");
            }
            await _cityRepository.CreateAsync(_mapper.Map<City>(model));
        }

        public async Task<IEnumerable<CityDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<CityDto>>(_cityRepository.FindAll(m=>m.Country));
        }

        public CityDetailDto GetById(int id)
        {
            var data = _cityRepository.FindBy(m => m.Id == id, m => m.Country).FirstOrDefault();
            return _mapper.Map<CityDetailDto>(data);
        }

        public CityDetailDto GetByName(string name)
        {
            var data = _cityRepository.FindBy(m => m.Name == name, m => m.Country).FirstOrDefault();
            return _mapper.Map<CityDetailDto>(data);
        }
    }
}

using AutoMapper;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using Repository.Repositories.Interfaces;
using Service.DTOs.Countries;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CountryService> _logger;
        public CountryService(ICountryRepository countryRepository, IMapper mapper, ILogger<CountryService> logger)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task CreateAsync(CountryCreateDto request)
        {
            if(request is null) throw new ArgumentException();
            await _countryRepository.CreateAsync(_mapper.Map<Country>(request));
        }

        public async Task DeleteAsync(int? id)
        {
            if(id is null)
            {
                _logger.LogWarning("Id is null");
                throw new ArgumentNullException();
            }
            var country = await _countryRepository.GetByIdAsync((int)id);
            await _countryRepository.DeleteAsync(country);
        }

        public async Task EditAsync(Country country,CountryEditDto request)
        {
            _mapper.Map(request, country);
            await _countryRepository.UpdateAsync(country);
        }

        public async Task<IEnumerable<CountryDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<CountryDto>>(await _countryRepository.GetAllAsync());
        }

        public async Task<Country> GetById(int id)
        {
            return await _countryRepository.GetByIdAsync(id);
        }
    }
}

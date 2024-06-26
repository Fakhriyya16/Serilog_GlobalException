using Domain.Entities;
using Service.DTOs.Countries;

namespace Service.Services.Interfaces
{
    public interface ICountryService
    {
        Task<IEnumerable<CountryDto>> GetAllAsync();
        Task CreateAsync(CountryCreateDto request);
        Task EditAsync(Country country,CountryEditDto request);
        Task DeleteAsync(int? id);
        Task<Country> GetById(int id);
    }
}

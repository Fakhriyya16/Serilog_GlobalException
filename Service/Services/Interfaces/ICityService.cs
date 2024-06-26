
using Service.DTOs.Cities;

namespace Service.Services.Interfaces
{
    public interface ICityService
    {
        Task<IEnumerable<CityDto>> GetAll();
        CityDetailDto GetById(int id);
        CityDetailDto GetByName(string name);
        Task CreateAsync(CityCreateDto model);
    }
}

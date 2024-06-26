
namespace Service.DTOs.Cities
{
    public class CityDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CountryName { get; set; }
    }
}

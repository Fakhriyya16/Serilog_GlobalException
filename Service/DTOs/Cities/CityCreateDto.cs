
using FluentValidation;

namespace Service.DTOs.Cities
{
    public class CityCreateDto
    {
        public string Name { get; set; }
        public int Population { get; set; }
        public int CountryId { get; set; }
    }

    public class CityCreateDtoValidator : AbstractValidator<CityCreateDto>
    {
        public CityCreateDtoValidator()
        {
            RuleFor(m=>m.Name).NotEmpty();
            RuleFor(m=>m.Population).NotEmpty();
            RuleFor(m=>m.CountryId).NotEmpty();
        }
    }
}

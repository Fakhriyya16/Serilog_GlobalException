using FluentValidation;

namespace Service.DTOs.Cities
{
    public class CityEditDto
    {
        public string Name { get; set; }
        public int Population { get; set; }
        public int CountryId { get; set; }
    }

    public class CityEditDtoValidator : AbstractValidator<CityEditDto>
    {
        public CityEditDtoValidator()
        {
            RuleFor(m=>m.Name).NotEmpty();
            RuleFor(m=>m.Population).NotEmpty();
            RuleFor(m=>m.CountryId).NotEmpty();
        }
    }
}

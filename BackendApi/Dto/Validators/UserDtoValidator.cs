using BackendApi.Models;
using BackendApi.Repositories;

namespace BackendApi.Dto.Validators
{
    public interface IUserDtoValidator
    {
        public Task<bool> ValidateAsync(UserDto user);
    }

    public class UserDtoValidator : IUserDtoValidator
    {
        private readonly ICountryDtoValidator countryDtoValidator;
        private readonly ICountryRepository countryRepository;

        public UserDtoValidator(ICountryDtoValidator countryDtoValidator, ICountryRepository countryRepository)
        {
            this.countryDtoValidator = countryDtoValidator;
            this.countryRepository = countryRepository;
        }

        public async Task<bool> ValidateAsync(UserDto dto)
        {
            if (dto.Login is null ||
                dto.Password is null ||
                dto.PasswordConfirm is null ||
                dto.Agree is null ||
                dto.Country is null ||
                dto.Province is null)
            {
                return false;
            }

            if (dto.Password != dto.PasswordConfirm)
                return false;

            if (!dto.Agree.Value)
                return false;

            var countryDto = dto.Country.Value;
            var provinceDto = dto.Province.Value;

            if (provinceDto.ID is null)
                return false;

            if (! await countryDtoValidator.ValidateAsync(countryDto))
                return false;

            var country = await countryRepository.GetByIdAsync(countryDto.ID!.Value);
            if (country is null)
                return false;

            if (!country.Provinces.Select(p => p.ID).Contains(provinceDto.ID.Value))
                return false;

            return true;
        }
    }
}

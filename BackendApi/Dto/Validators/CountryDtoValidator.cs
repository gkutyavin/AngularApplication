using BackendApi.Models;
using BackendApi.Repositories;

namespace BackendApi.Dto.Validators
{
    public interface ICountryDtoValidator
    {
        public Task<bool> ValidateAsync(CountryDto dto);
    }

    public class CountryDtoValidator : ICountryDtoValidator
    {
        private readonly ICountryRepository repository;

        public CountryDtoValidator(ICountryRepository repository)
        {
            this.repository = repository;
        }

        public async Task<bool> ValidateAsync(CountryDto dto)
        {
            if (dto.ID is null ||
                dto.Name is null)
            {
                return false;
            }

            if (dto.ID > 0)
            {
                var country = await repository.GetByIdAsync(dto.ID.Value);
                if (country is null)
                    return false;
            }

            return true;
        }
    }
}

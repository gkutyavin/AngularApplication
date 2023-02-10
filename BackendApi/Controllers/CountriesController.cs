using BackendApi.Dto;
using BackendApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryRepository repository;

        public CountriesController(ICountryRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<CountryDto>> GetAsync()
        {
            var countries = await repository.GetAllAsync();

            return countries.Select(country => new CountryDto
            {
                ID = country.ID,
                Name = country.Name,
                Provinces = country.Provinces.Select(province => new ProvinceDto
                {
                    ID = province.ID,
                    Name = province.Name,
                }).ToArray(),
            });
        }
    }
}
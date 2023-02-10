using BackendApi.Models;

namespace BackendApi.Repositories
{
    public interface ICountryRepository
    {
        public Task<IEnumerable<Country>> GetAllAsync();
        public Task<Country?> GetByIdAsync(int id);
    }
}

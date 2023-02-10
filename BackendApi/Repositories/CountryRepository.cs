using BackendApi.Data;
using BackendApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendApi.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly AppDbContext dbContext;

        public CountryRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Country>> GetAllAsync() => await dbContext
            .Countries
            .Include(c => c.Provinces)
            .AsNoTracking()
            .ToListAsync();

        public async Task<Country?> GetByIdAsync(int id) => await dbContext
            .Countries
            .Include(c => c.Provinces)
            .FirstOrDefaultAsync(c => c.ID == id);
    }
}

using BackendApi.Data;
using BackendApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext dbContext;

        public UserRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Add(User user) 
        {
            dbContext.Users.Add(user);
            await dbContext.SaveChangesAsync();
        }
    }
}

using BackendApi.Models;

namespace BackendApi.Repositories
{
    public interface IUserRepository
    {
        public Task Add(User user);
    }
}

using api_pokelab.Models;

namespace api_pokelab.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByUsernameAsync(string username);
    }
}

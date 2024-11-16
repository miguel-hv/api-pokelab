using api_pokelab.Data;
using api_pokelab.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace api_pokelab.Repositories
{
    public class UserRepository(PokeDbContext context) : IUserRepository
    {
        public async Task<User> GetUserByUsernameAsync(string username)
        {
            // Simulate async database lookup
            return await context.Users.SingleOrDefaultAsync(u => u.Username == username); //TODO: check null

        }
    }
}

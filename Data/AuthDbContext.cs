using Microsoft.EntityFrameworkCore;
using testJWT.Users;

namespace testJWT.Data
{
    public class AuthDbContext: DbContext
    {
       public AuthDbContext(DbContextOptions<AuthDbContext> options): base (options)
       { 
       }
        public DbSet<User> Users { get; set; } = null!;
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using testJWT.Data;
using testJWT.Users.Infrastructure;

namespace testJWT.Users
{
    internal sealed class LoginUser(AuthDbContext context, PasswordHasher passwordHasher, TokenProvider tokenProvider)
    {
        public sealed record Request(string Email, string Password);

        public async Task<string> Handle(Request request)
        {
            //User? user = await context.Users.GetUser(request.Email); //TODO: pillar endpoint de context
            //User? user = await context.Users.FindAsync(request.Email);
            User user = new()
            {
                Email = "mail@mail.com",
                Name = "name",
                EmailVerified = true,
                PasswordHash = "passHash"
            };

            if (user is null || user.EmailVerified)
            {
                throw new Exception("The user was not found");
            }

            bool isVerified = passwordHasher.Verify(request.Password, user.PasswordHash);
            if (!isVerified )
            {

                throw new Exception("The password is incorrect");
            }
            string token = tokenProvider.Create(user);

            return token;
        }
    }
}

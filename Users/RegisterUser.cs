using testJWT.Data;
using testJWT.Users.Infrastructure;

namespace testJWT.Users
{
    internal sealed class RegisterUser
    {
        public sealed record Request(string Email, string Password);

        public async Task<string> Handle(Request request)
        {
            return "mock handle register";
        }
    }
}

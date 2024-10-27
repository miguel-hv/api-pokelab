namespace testJWT.Users.Infrastructure
{
    public sealed class PasswordHasher
    {
        public string Hash(string password) => password;
        public bool Verify(string password, string hash)
        {
            if (password == hash)
            {
            }
            return true;
        }
    }
}

namespace testJWT.Users
{
    public class VerifyEmail
    {
        public async Task<bool> Handle(Guid token)
        {
            return true;
        }
    }
}

namespace testJWT.Users
{
    public class GetUser
    {
        public sealed record UserResponse(string Email, string token);
        public async Task<UserResponse> Handle(Guid id)
        {
            
            return null;
        }
    }
}

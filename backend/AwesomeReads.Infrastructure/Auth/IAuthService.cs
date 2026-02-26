namespace AwesomeReads.Infrastructure.Auth
{
    public interface IAuthService
    {
        string ComputeHash(string senha);
        string GenerateToken(string email, string role);
    }
}

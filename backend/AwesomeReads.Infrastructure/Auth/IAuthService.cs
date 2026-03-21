namespace AwesomeReads.Infrastructure.Auth
{
    public interface IAuthService
    {
        string ComputeHash(string senha);
        string GenerateToken(int id, string email, string role);
    }
}

namespace OnlineStoreApplication.Service
{
    public interface IAuthService
    {
        string GetJWTToken(string userName, string role);
    }
}

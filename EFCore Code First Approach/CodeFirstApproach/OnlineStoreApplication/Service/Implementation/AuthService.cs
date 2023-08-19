using OnlineStoreApplication.Service;
using ProjectHelpers;

namespace OnlineStoreApplication.Service
{
    public class AuthService : IAuthService
    {
        public string GetJWTToken(string userName, string role)
        {
			try
			{
                var generateToken = new GenerateToken(userName,role);
                return generateToken.GetJWTToken();

            }
			catch (System.Exception)
			{
                return null;
			}
        }
    }
}

using BCrypt.Net;
using System.CodeDom.Compiler;
namespace DiscGolfBusiness
{
    public class SecurityHelper
    {
        public static string GeneratedPasswordHash(string password)
        {
            return BCrypt.Net.BCrypt.EnhancedHashPassword(password, 13);
        }

        public static bool VerifyPassword(string password, string passwordhash)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(password, passwordhash);
        }
        public static string GetDBConnectionString()
        {
            string connString = "Server=(localdb)\\MSSQLLocalDB;Database=DiscGolfDatabase;Trusted_Connection=true;";
            return connString;

        }
    }
}

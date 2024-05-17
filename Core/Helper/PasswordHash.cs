using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace Core.Helper
{

    public interface IPasswordHelper
    {
        public string HashPassword(string password);

        public bool VerifyPassword(string password, string encryptPassword);
    }

    public class PasswordHelper : IPasswordHelper
    {
        private readonly IConfiguration _configuration;
        public PasswordHelper(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public string HashPassword(string password)
        {
            var salt = this._configuration["Hashing:Salt"];
            byte[] hashByte = KeyDerivation.Pbkdf2(password, Encoding.UTF8.GetBytes(salt),KeyDerivationPrf.HMACSHA1, 100000, 256 / 8);
            return Convert.ToBase64String(hashByte);
        }

        public bool VerifyPassword(string password,string encryptPassword)
        {
            string hashPassword = HashPassword(password);
            return string.Equals(hashPassword, encryptPassword, StringComparison.OrdinalIgnoreCase);
        }

    }
}

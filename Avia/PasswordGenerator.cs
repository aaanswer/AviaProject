using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Avia
{
    public static class PasswordGenerator
    {
        public static string generateDefaultPassword()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                string AllCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                byte[] randomBytes = new byte[12];
                rng.GetBytes(randomBytes);

                return new string(randomBytes.Select(b => AllCharacters[b % AllCharacters.Length]).ToArray());
            }
        }
        public static string hashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
    }    
}

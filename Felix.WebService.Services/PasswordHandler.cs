using Felix.WebService.Data.Models.Identity;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Felix.WebService.Services
{
    /// <summary>
    /// Functions for handling passwords
    /// </summary>
    public static class PasswordHandler
    {
        private static readonly int SaltLength = 10;

        public static bool CheckPassword(User user, string rawPassword)
        {
            string hashedPassword = GetHashedPassword(user.Salt, rawPassword);

            return hashedPassword == user.Password;
        }

        /// <summary>
        /// Creates a random salt for password hashing
        /// </summary>
        /// <returns></returns>
        public static string CreateRandomSalt()
        {
            RNGCryptoServiceProvider cryptoServiceProvider= new();
            byte[] salt = new byte[SaltLength];
            cryptoServiceProvider.GetNonZeroBytes(salt);
            
            return Convert.ToBase64String(salt);
        }

        /// <summary>
        /// Creates a hash from a salt and a raw password
        /// </summary>
        /// <param name="salt"></param>
        /// <param name="rawPassword"></param>
        /// <returns></returns>
        public static string GetHashedPassword(string salt, string rawPassword)
        {
            using MD5 hash = MD5.Create();
            using MemoryStream inputStream = new(Encoding.UTF8.GetBytes($"{salt}{rawPassword}"));
            var computedHash = hash.ComputeHash(inputStream);
            var stringBuilder = new StringBuilder();
            foreach (var x in computedHash)
            {
                stringBuilder.AppendFormat("{0:x2}", x);
            }

            return stringBuilder.ToString();
        }
    }
}

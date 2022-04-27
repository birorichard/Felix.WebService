using Felix.WebService.Common.Constants;
using Felix.WebService.DAL;
using Microsoft.Extensions.Configuration;
using System;

namespace Felix.WebService.Services.Seeds
{
    public class AdminDataSeed : IDataSeed
    {
        private readonly IConfiguration _configuration;

        public AdminDataSeed(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Guid Guid => new("D7499DD5-9B1D-4AAB-A0D9-A12A00FF9A77");

        public void SeedData(UnitOfWork unitOfWork)
        {
            string salt = PasswordHandler.CreateRandomSalt();
            string hashedPassword = PasswordHandler.GetHashedPassword(salt, _configuration[ConfigKeyConstants.DefaultAdminPassword]);
            unitOfWork.UserRepository.Create(new()
            {
                UserName = "admin",
                Name = "Admin",
                Password = hashedPassword,
                Salt = salt,
                IsAdmin = true
            });
        }
    }
}

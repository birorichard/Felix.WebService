using Felix.WebService.Common.Constants;
using Felix.WebService.DAL;
using Felix.WebService.Data.Models.Identity;
using Felix.WebService.Enums;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace Felix.WebService.Services.Seeds
{
    public class TestUsersDataSeed : IDataSeed
    {
        private readonly IConfiguration _configuration;

        public TestUsersDataSeed(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Guid Guid => new("1B6C4C3F-63F7-4DE5-BC97-E7EC5DDBCA8E");

        public void SeedData(UnitOfWork unitOfWork)
        {
            string salt;
            string hashedPassword;

            salt = PasswordHandler.CreateRandomSalt();
            hashedPassword = PasswordHandler.GetHashedPassword(salt, _configuration[ConfigKeyConstants.DefaultTestUserPassword]);
            List<User> users = new()
            {
                new()
                {
                    UserName = "test.bela",
                    Name = "Teszt Béla",
                    Password = hashedPassword,
                    Salt = salt
                },
                new()
                {
                    UserName = "test.gabor",
                    Name = "Teszt Gábor",
                    Password = hashedPassword,
                    Salt = salt
                },
                new()
                {
                    UserName = "test.jozsi",
                    Name = "Teszt József",
                    Password = hashedPassword,
                    Salt = salt
                },
                new()
                {
                    UserName = "test.feco",
                    Name = "Teszt Ferenc",
                    Password = hashedPassword,
                    Salt = salt
                }
            };

            unitOfWork.UserRepository.CreateRange(users);
        }
    }
}

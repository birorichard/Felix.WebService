using Felix.WebService.DAL;
using Felix.WebService.Data.Models.Movie;
using System;
using System.Collections.Generic;

namespace Felix.WebService.Services.Seeds
{
    public class ExampleProjectsDataSeed : IDataSeed
    {
        public Guid Guid => new("0F7DE847-F9CC-43AB-B79E-DB16B85D462A");

        public void SeedData(UnitOfWork unitOfWork)
        {
            unitOfWork.MovieRepository.CreateRange(new List<Movie>
            {
                new()
                {
                    Name = "Iron Man",
                    CodeName = "iron_man",
                    CreatedAt = DateTime.Now.AddYears(-17).AddMonths(-3).AddDays(-10)
                },
                new()
                {
                    Name = "Spiderman: Homecoming",
                    CodeName = "spiderman_homecoming",
                    CreatedAt = DateTime.Now.AddMonths(-7).AddDays(-23)
                },
                new()
                {
                    Name = "Avengers: Endgame",
                    CodeName = "avengers_endgame",
                    CreatedAt = DateTime.Now.AddYears(-5).AddMonths(-11).AddDays(-5)
                }
            });
        }
    }
}

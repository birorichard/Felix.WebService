using Felix.WebService.DAL;
using Felix.WebService.Data.Models.Movie;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Felix.WebService.Services.Seeds
{
    public class ExampleCutsDataSeed : IDataSeed
    {
        public Guid Guid => new("9B80CBFA-EC91-4714-8F7E-8BF5CFC723E1");

        public void SeedData(UnitOfWork unitOfWork)
        {
            Movie endgame = unitOfWork.MovieRepository.Get(x => x.CodeName.Equals("avengers_endgame")).FirstOrDefault();
            
            unitOfWork.CutRepository.CreateRangeAsync(new List<Cut>
            {
                new()
                {
                    Name = "Example cut 01",
                    Movie = endgame,
                    CreatedAt = DateTime.Now.AddDays(-5),
                    ModifiedAt = DateTime.Now.AddDays(-4)
                },
                new()
                {
                    Name = "Example cut 02",
                    Movie = endgame,
                    CreatedAt = DateTime.Now.AddDays(-3),
                    ModifiedAt = DateTime.Now.AddDays(-1).AddHours(8).AddMinutes(-10)
                }
            });
        }
    }
}

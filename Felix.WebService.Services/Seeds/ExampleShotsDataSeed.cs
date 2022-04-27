using Felix.WebService.DAL;
using Felix.WebService.Data.Models.Movie;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Felix.WebService.Services.Seeds
{
    public class ExampleShotsDataSeed : IDataSeed
    {
        public Guid Guid => new("1E60729B-15EC-45C0-8DF4-9458079D61D0");

        public void SeedData(UnitOfWork unitOfWork)
        {
            Cut cut_v1 = unitOfWork.CutRepository.Get(x => x.Name.Equals("Példa vágás 01")).FirstOrDefault();
            Cut cut_v2 = unitOfWork.CutRepository.Get(x => x.Name.Equals("Példa vágás 02")).FirstOrDefault();

            List<Shot> shots_v1 = new()
            {
                new()
                {
                    Name = "shot-1",
                    StartFrame = 1,
                    EndFrame = 33,
                    FileName = "shot1-v1.mp4"
                },
                new()
                {
                    Name = "shot-2",
                    StartFrame = 34,
                    EndFrame = 113,
                    FileName = "shot2-v1.mp4"
                },
                new()
                {
                    Name = "shot-3",
                    StartFrame = 114,
                    EndFrame = 137,
                    FileName = "shot3-v1.mp4"
                },
                new()
                {
                    Name = "shot-4",
                    StartFrame = 138,
                    EndFrame = 231,
                    FileName = "shot4-v1.mp4"
                }
            };

            unitOfWork.ShotRepository.CreateRange(shots_v1);

            unitOfWork.ShotCutRelRepository.CreateRange(shots_v1.Select<Shot, ShotCutRel>(shot =>
            {
                return new ()
                {
                    Shot = shot,
                    Cut = cut_v1
                };
            }));

            List<Shot> shots_v2 = new()
            {
                new()
                {
                    Name = "shot-1-v2",
                    StartFrame = 0,
                    EndFrame = 32,
                    FileName = "shot1-v2.mp4"
                },
                new()
                {
                    Name = "shot-2-v2",
                    StartFrame = 33,
                    EndFrame = 112,
                    FileName = "shot2-v2.mp4"
                },
                new()
                {
                    Name = "shot-3-v2",
                    StartFrame = 113,
                    EndFrame = 136,
                    FileName = "shot3-v2.mp4"
                },
                new()
                {
                    Name = "shot-4-v2",
                    StartFrame = 137,
                    EndFrame = 230,
                    FileName = "shot4-v2.mp4"
                }
            };

            unitOfWork.ShotRepository.CreateRange(shots_v2);

            unitOfWork.ShotCutRelRepository.CreateRange(shots_v2.Select<Shot, ShotCutRel>(shot =>
            {
                return new()
                {
                    Shot = shot,
                    Cut = cut_v2
                };
            }));
        }
    }
}

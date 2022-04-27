using Felix.WebService.DAL;
using Felix.WebService.Services.Interfaces;
using Felix.WebService.Services.Seeds;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Felix.WebService.Data
{
    public class SeedService : ISeedService
    {
        private readonly IEnumerable<IDataSeed> _dataSeeds;
        private readonly UnitOfWork _untiOfWork;

        public SeedService(IEnumerable<IDataSeed> dataSeeds, UnitOfWork untiOfWork)
        {
            _dataSeeds = dataSeeds;
            _untiOfWork = untiOfWork;
        }
        public async Task SeedAll(CancellationToken cancellationToken = default)
        {
            foreach (IDataSeed seed in _dataSeeds)
            {
                if (!_untiOfWork.SeedRepository.Any(x => x.Guid == seed.Guid))
                {
                    seed.SeedData(_untiOfWork);
                    _untiOfWork.SeedRepository.Create(new()
                    {
                        Guid = seed.Guid,
                        CreatedDate = DateTime.Now
                    });
                }

                await _untiOfWork.SaveAsync(cancellationToken);
            }
        }
    }
}

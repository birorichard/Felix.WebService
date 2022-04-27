using Felix.WebService.DAL;
using System;

namespace Felix.WebService.Services.Seeds
{
    public interface IDataSeed
    {
        public abstract Guid Guid { get; }
        public void SeedData(UnitOfWork unitOfWork);
    }
}

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace Felix.WebService.Data
{
    /// <summary>
    /// Factory for DbContext type. Used for Entity Framework migrations.
    /// </summary>
    public class MigrationDbContextFactory : IDesignTimeDbContextFactory<FelixDbContext>
    {
        private static string InitalCatalog => Environment.GetEnvironmentVariable("FelixDbInitialCatalog");
        private static string DataSource => Environment.GetEnvironmentVariable("FelixDbDataSource");

        public MigrationDbContextFactory()
        {
        }

        public FelixDbContext CreateDbContext(string[] args)
        {

            var connectionStringBuilder = new SqlConnectionStringBuilder
            {
                InitialCatalog = InitalCatalog,
                DataSource = DataSource
            };

            var optionsBuilder = new DbContextOptionsBuilder<FelixDbContext>();
            optionsBuilder.UseSqlServer(connectionStringBuilder.ConnectionString);
            
            return new FelixDbContext(optionsBuilder.Options);
        }
    }
}

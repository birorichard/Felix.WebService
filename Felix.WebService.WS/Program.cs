using Azure.Identity;
using Felix.WebService.Common.Constants;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Azure.KeyVault;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureKeyVault;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace Felix.WS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
            .ConfigureAppConfiguration((context, config) =>
            {
                /// Az Azure Key Vault should not be set in localhost environment. Only used in Production.
                if (context.HostingEnvironment.IsProduction())
                {
                    var builtConfig = config.Build();
                    string vaultName = builtConfig[ConfigKeyConstants.KeyVaultConfigKeyName];
                    KeyVaultClient client = new((authority, resource, scope) =>
                    {
                        DefaultAzureCredential credential = new(includeInteractiveCredentials: false);
                        var token = credential.GetToken(requestContext: new Azure.Core.TokenRequestContext(new[] { ConnectionConstants.DefaultAzureKeyVaultScope }));
                        return Task.FromResult(token.Token);
                    });
                    config.AddAzureKeyVault(vaultName, client, new DefaultKeyVaultSecretManager());
                }
            });
    }
}

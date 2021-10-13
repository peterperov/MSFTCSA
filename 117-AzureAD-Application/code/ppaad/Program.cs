using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Extensions.Configuration.AzureKeyVault;
using Azure.Identity;

namespace WebApp_OpenIDConnect_DotNet
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
                .ConfigureAppConfiguration((ctx, builder) =>
                {
                    var keyVaultEndpoint = GetKeyVaultEndpoint();
                    if (!string.IsNullOrEmpty(keyVaultEndpoint))
                    {
                        var azureServiceTokenProvider = new AzureServiceTokenProvider();
                        var keyVaultClient = new KeyVaultClient(
                            new KeyVaultClient.AuthenticationCallback(
                                azureServiceTokenProvider.KeyVaultTokenCallback));
                        builder.AddAzureKeyVault(
                            keyVaultEndpoint, keyVaultClient, new DefaultKeyVaultSecretManager());
                    }
                })
            ;


        // PP: this is now being included into CreateHostBuilder
        public static IWebHost BuildWebHost(string[] args) =>
               WebHost.CreateDefaultBuilder(args)
                   .ConfigureAppConfiguration((ctx, builder) =>
                   {
                       var keyVaultEndpoint = GetKeyVaultEndpoint();
                       if (!string.IsNullOrEmpty(keyVaultEndpoint))
                       {
                           var azureServiceTokenProvider = new AzureServiceTokenProvider();
                           var keyVaultClient = new KeyVaultClient(
                               new KeyVaultClient.AuthenticationCallback(
                                   azureServiceTokenProvider.KeyVaultTokenCallback));
                           builder.AddAzureKeyVault(
                               keyVaultEndpoint, keyVaultClient, new DefaultKeyVaultSecretManager());
                       }
                   }
                ).UseStartup<Startup>()
                 .Build();

        private static string GetKeyVaultEndpoint() => "https://ppkeyvault01.vault.azure.net/";

    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApp_OpenIDConnect_DotNet.Models;
using Microsoft.Extensions.Configuration;
using Azure.Security.KeyVault.Secrets;
using Azure.Core;
using Azure.Identity;

namespace WebApp_OpenIDConnect_DotNet.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        // requires using Microsoft.Extensions.Configuration;
        private readonly IConfiguration Configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            Configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }


        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Secret()
        {
            ViewData["Message"] = "Your Settings page.";

            var list = new List<KeyValuePair<string, string>>();

            list.Add(new KeyValuePair<string, string>("key1", "value"));



            list.Add(new KeyValuePair<string, string>("MySecret", GetSecret("mysecret")));
            list.Add(new KeyValuePair<string, string>("ExamplePassword", Configuration["ExamplePassword"]));
            list.Add(new KeyValuePair<string, string>("StorageConnectionString", Configuration["StorageConnectionString"]));
            list.Add(new KeyValuePair<string, string>("testsecret001", Configuration["testsecret001"]));



            list.Add(new KeyValuePair<string, string>("StorageConnectionString", Configuration["StorageConnectionString"]));
            list.Add(new KeyValuePair<string, string>("ExamplePassword", Configuration["ExamplePassword"]));


            ViewBag.list = list;


            return View();
        }


        private string GetSecret(string name)
        {
            SecretClientOptions options = new SecretClientOptions()
            {
                Retry =
        {
            Delay= TimeSpan.FromSeconds(2),
            MaxDelay = TimeSpan.FromSeconds(16),
            MaxRetries = 5,
            Mode = RetryMode.Exponential
         }
            };
            var client = new SecretClient(new Uri("https://ppkeyvault01.vault.azure.net/"), new DefaultAzureCredential(), options);

            KeyVaultSecret secret = client.GetSecret(name);

            string secretValue = secret.Value;

            return "";
        }


        [Authorize]
        public IActionResult Claims()
        {
            ViewBag.Message = "Your application description page.";

            var dic = new Dictionary<string, string>();

            if (this.User != null)
            {
                foreach (var c in this.User.Claims)
                {
                    dic.Add(c.Type, c.Value);
                }
            }



            return View(new ClaimModel() { Claims = dic });
        }



    }
}

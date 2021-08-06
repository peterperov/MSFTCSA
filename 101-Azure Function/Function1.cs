using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace _101_Azure_Function
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            // name = name ?? data?.name;

            var peterKey = GetEnvironmentVariable("PETER_KEY");

            var url = GetEnvironmentVariable("FILE_URL");
            var str = ""; 

            var buffer = new StringBuilder();

            if (!string.IsNullOrEmpty(url))
            {

                var client = new WebClient();
                str = client.DownloadString(url);

                
                buffer.Append(string.IsNullOrEmpty(name)
                    ? $"This HTTP triggered function executed successfully. Pass a name in the query string. PETER_KEY = {peterKey}"
                    : $"Hello, {name}. This HTTP triggered function executed successfully.");
            }
            else
            {
                buffer.Append("FILE_URL was not specified in the app settings");
            }


            buffer.Append("\n\n");
            buffer.Append(str); 

            return new OkObjectResult(buffer.ToString());
        }


        private static string GetEnvironmentVariable(string name)
        {
            return System.Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.Process);
        }

    }


}

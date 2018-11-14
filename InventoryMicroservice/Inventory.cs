using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using InventoryMicroservice.Handlers;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace InventoryMicroservice
{
    public static class Inventory
    {
        [FunctionName("Function1")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            // parse query parameter
            string name = req.GetQueryNameValuePairs()
                .FirstOrDefault(q => string.Compare(q.Key, "name", true) == 0)
                .Value;

            if (name == null)
            {
                //test
                // Get request body
                dynamic data = await req.Content.ReadAsAsync<object>();
                name = data?.name;
            }

            UnityConfig.RegisterComponents();
            //MapConfig.RegisterMapping();


            new InventoryHandler(UnityConfig.Container).Run();

            return req.CreateResponse(HttpStatusCode.OK, "Succes");
        }
    }
}

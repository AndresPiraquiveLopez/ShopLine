using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using InventoryBusinessLogic.Initializers;
using InventoryMicroservice.Handlers;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace InventoryMicroservice
{
    public static class InventoryApi
    {
        [FunctionName("AddProduct")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            // parse query parameter
            string name = req.GetQueryNameValuePairs()
                .FirstOrDefault(q => string.Compare(q.Key, "name", true) == 0)
                .Value;

            object data = null;

            if (name == null)
            {
                //test
                // Get request body
                data = await req.Content.ReadAsAsync<object>();
            }

            UnityConfig.RegisterComponents();
            MapConfig.RegisterMapping();


            var id = new InventoryHandler(UnityConfig.Container).Add(data.ToString());

            return req.CreateResponse(HttpStatusCode.OK, "Succes");
        }

        [FunctionName("AdjStock")]
        public static async Task<HttpResponseMessage> Run1([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            // parse query parameter
            string name = req.GetQueryNameValuePairs()
                .FirstOrDefault(q => string.Compare(q.Key, "name", true) == 0)
                .Value;

            object data = null;

            if (name == null)
            {
                //test
                // Get request body
                data = await req.Content.ReadAsAsync<object>();
            }

            UnityConfig.RegisterComponents();
            MapConfig.RegisterMapping();


            new InventoryHandler(UnityConfig.Container).AdjStock(data.ToString());

            return req.CreateResponse(HttpStatusCode.OK, "Succes");
        }

    }
}

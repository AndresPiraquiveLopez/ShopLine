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
        [FunctionName("AddToStock")]
        public static async Task<HttpResponseMessage> AddToStock([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
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


            var id = new InventoryHandler(UnityConfig.Container).AddToStock(data.ToString());

            return req.CreateResponse(HttpStatusCode.OK, "Succes");
        }

        [FunctionName("AdjStock")]
        public static async Task<HttpResponseMessage> AdjStock([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
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

        [FunctionName("TransfertQtyStock")]
        public static async Task<HttpResponseMessage> TransfertQtyStock([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
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


            new InventoryHandler(UnityConfig.Container).TransfertQtyStock(data.ToString());

            return req.CreateResponse(HttpStatusCode.OK, "Succes");
        }

        [FunctionName("RemoveFromStock")]
        public static async Task<HttpResponseMessage> RemoveFromStock([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
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


            new InventoryHandler(UnityConfig.Container).RemoveFromStock(data.ToString());

            return req.CreateResponse(HttpStatusCode.OK, "Succes");
        }

        [FunctionName("AddProduct")]
        public static async Task<HttpResponseMessage> AddProduct([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
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


            new InventoryHandler(UnityConfig.Container).AddProduct(data.ToString());

            return req.CreateResponse(HttpStatusCode.OK, "Succes");
        }

        [FunctionName("GetProduct")]
        public static async Task<HttpResponseMessage> GetProduct([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
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


            var product = new InventoryHandler(UnityConfig.Container).GetProduct(data.ToString());

            return req.CreateResponse(HttpStatusCode.OK, "Succes");
        }

    }
}

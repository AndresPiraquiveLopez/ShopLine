using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using CartBusinessLogic.Initializers;
using CartMicroservice.Handlers;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;

namespace CartMicroservice
{
    public static class CartApi
    {
        //[FunctionName("AddItem")]
        //public static async Task<HttpResponseMessage> AddItem([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        //{
        //    log.Info("C# HTTP trigger function processed a request.");

        //    // parse query parameter
        //    string name = req.GetQueryNameValuePairs()
        //        .FirstOrDefault(q => string.Compare(q.Key, "name", true) == 0)
        //        .Value;
        //    object data = null;

        //    if (name == null)
        //    {
        //        // Get request body
        //        data = await req.Content.ReadAsAsync<object>();
        //    }

        //    UnityConfig.RegisterComponents();
        //    MapConfig.RegisterMapping();

        //    new CartHandler(UnityConfig.Container).UpdateQtyItem(data.ToString());
        //    return req.CreateResponse(HttpStatusCode.OK, "Succes");
        //}

        [FunctionName("AddItem")]
        public static async Task<HttpResponseMessage> AddItem([HttpTrigger(AuthorizationLevel.Function, "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            // parse query parameter
            string name = req.GetQueryNameValuePairs()
                .FirstOrDefault(q => string.Compare(q.Key, "name", true) == 0)
                .Value;
            object data = null;

            if (name == null)
            {
                // Get request body
                data = await req.Content.ReadAsAsync<object>();
            }

            UnityConfig.RegisterComponents();
            MapConfig.RegisterMapping();
         

            var id = new CartHandler(UnityConfig.Container).AddItem(data.ToString());
            if(id > 0)
                return req.CreateResponse(HttpStatusCode.OK, "Success");
            else
                return req.CreateResponse(HttpStatusCode.Forbidden, "Forbidden");
        }

        [FunctionName("GetCartItems")]
        public static async Task<HttpResponseMessage> GetCartItems([HttpTrigger(AuthorizationLevel.Function, "get", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            // parse query parameter
            string name = req.GetQueryNameValuePairs()
                .FirstOrDefault(q => string.Compare(q.Key, "name", true) == 0)
                .Value;
            object data = null;

            if (name == null)
            {
                // Get request body
                data = await req.Content.ReadAsAsync<object>();
            }

            UnityConfig.RegisterComponents();
            MapConfig.RegisterMapping();




            var cartItems = new CartHandler(UnityConfig.Container).GetCartItems();
            //req.Content = new StringContent(JsonConvert.SerializeObject(cartItems));
            if (cartItems !=  null)
                return req.CreateResponse(HttpStatusCode.OK, cartItems);
            else
                return req.CreateResponse(HttpStatusCode.NotFound, "NotFound");
        }

        [FunctionName("UpdateQtyItem")]
        public static async Task<HttpResponseMessage> UpdateQtyItem([HttpTrigger(AuthorizationLevel.Function, "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            // parse query parameter
            string name = req.GetQueryNameValuePairs()
                .FirstOrDefault(q => string.Compare(q.Key, "name", true) == 0)
                .Value;
            object data = null;

            if (name == null)
            {
                // Get request body
                data = await req.Content.ReadAsAsync<object>();
            }

            UnityConfig.RegisterComponents();
            MapConfig.RegisterMapping();


            var id = new CartHandler(UnityConfig.Container).UpdateQtyItem(data.ToString());
            if (id > 0)
                return req.CreateResponse(HttpStatusCode.OK, "Success");
            else
                return req.CreateResponse(HttpStatusCode.Forbidden, "Forbidden");
        }
    }
}

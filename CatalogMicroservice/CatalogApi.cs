using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

using CatalogBusinessLogic.Initializers;
using CatalogMicroservice.Handlers;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace CatalogMicroservice
{
    public static class CatalogApi
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
                // Get request body
                data = await req.Content.ReadAsAsync<object>();
            }

            UnityConfig.RegisterComponents();
            MapConfig.RegisterMapping();

            new CatalogHandler(UnityConfig.Container).AddProduct(data.ToString());
            return req.CreateResponse(HttpStatusCode.OK, "Succes");
        }

        [FunctionName("CategoryList")]
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
                // Get request body
                data = await req.Content.ReadAsAsync<object>();
            }

            UnityConfig.RegisterComponents();
            MapConfig.RegisterMapping();

            var listCategory = new CatalogHandler(UnityConfig.Container).Catalog(data.ToString());
            return req.CreateResponse(HttpStatusCode.OK, listCategory);
        }

    

        //get list produits - paulo
        [FunctionName("ProductList")]
        public static async Task<HttpResponseMessage> Run2([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
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

            var listProduct = new CatalogHandler(UnityConfig.Container).Category(data.ToString());
            return req.CreateResponse(HttpStatusCode.OK, listProduct);
        }


        //paulo get details produit
        [FunctionName("ProductDetails")]
        public static async Task<HttpResponseMessage> Run3([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
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

            var productDetails = new CatalogHandler(UnityConfig.Container).products(data.ToString());
            return req.CreateResponse(HttpStatusCode.OK, productDetails);
        }

    }
}
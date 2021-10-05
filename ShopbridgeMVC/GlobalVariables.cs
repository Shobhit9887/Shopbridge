using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ShopbridgeMVC
{
    public static class GlobalVariables
    {
        public static HttpClient shopBridgeClient = new HttpClient();

        static GlobalVariables()
        {
            shopBridgeClient.BaseAddress = new Uri("https://localhost:44323/api/");
            shopBridgeClient.DefaultRequestHeaders.Clear();
            shopBridgeClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PFLFri3.Models;

namespace PFLFri3.Controllers
{
    public class APIServices
    {
        public static HttpClient getHttpClient()
        {
            HttpClient httpClient = new HttpClient();

            string auth = File.ReadAllText("Auth.txt");

            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", auth);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return httpClient;
        }

        public static RootObjectProduct LoadJsonLocal()
        {
            RootObjectProduct rObj = null;

            using (StreamReader r = new StreamReader("file.json"))
            {
                string json = r.ReadToEnd();
                rObj = JsonConvert.DeserializeObject<RootObjectProduct>(json);
            }

            return rObj;
        }

        public static async Task<RootObjectProduct> GetProducts()
        {
            string uri = "https://testapi.pfl.com/products?apikey=136085";

            HttpClient httpClient = getHttpClient();

            using (var result = await httpClient.GetAsync(uri))
            {
                RootObjectProduct rObj = null;
                if (result.IsSuccessStatusCode)
                {
                    string content = await result.Content.ReadAsStringAsync();
                    rObj = JsonConvert.DeserializeObject<RootObjectProduct>(content);
                }

                return rObj;
            }
        }

        public static async Task<RootObjectDetail> GetProductDetails(int id)
        {
            HttpClient httpClient = getHttpClient();

            string uri = "https://testapi.pfl.com/products?apikey=136085&id=";
            
            using (var result = await httpClient.GetAsync(uri + id))
            {
                RootObjectDetail rObj = null;
                if (result.IsSuccessStatusCode)
                {
                    string content = await result.Content.ReadAsStringAsync();
                    rObj = JsonConvert.DeserializeObject<RootObjectDetail>(content);
                }

                return rObj;
            }
        }

        public static async Task<string> PostOrder(Order order)
        {
            string uri = "https://testapi.pfl.com/products?apikey=136085";

            HttpClient httpClient = getHttpClient();

            var content = new StringContent(JsonConvert.SerializeObject(order).ToString(), Encoding.UTF8, "application/json");
            var result = await httpClient.PostAsync(uri, content);

            return "";
        }

    }
}

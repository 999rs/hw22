using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DomainBasic;
using Newtonsoft.Json;
using System.Text;
//using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.IO;
using System.Net.Http.Json;
using System.Configuration;

namespace hw20
{
    public static class DataApiCalls 
    {
        static DataApiCalls() 
        {
            RootUrl = System.Configuration.ConfigurationManager.AppSettings["apiUrl"]; //"http://localhost:2021";

            

        }

        public static string RootUrl { get; set; }
        

        public static  class Products  
        {
            public static Product GetProductById(int id)
            {
                HttpClient httpClient = new HttpClient();
                string url = $"{RootUrl}/api/products/{id}";

                string json = httpClient.GetStringAsync(url).Result;

                var x = JsonConvert.DeserializeObject<Product>(json);
                return x;

                //return new Product();    
            }

            public static List<Product> GetAllProducts()
            {
                HttpClient httpClient = new HttpClient();
                string url = $"{RootUrl}/api/products";

                string json = httpClient.GetStringAsync(url).Result;
                var x = JsonConvert.DeserializeObject<List<Product>>(json);

                return x;
            }

            public static void SaveImagesTo(string path)
            {
                var list = GetAllProducts();
                foreach (var p in list)
                {
                    var file = Path.Combine(path, p.Id.ToString() + ".jpeg");

                    File.WriteAllBytesAsync(file, p.ImageData);

                }
            }


            public static HttpResponseMessage Create(Product item)
            {
                HttpClient httpClient = new HttpClient();
                string url = $"{RootUrl}/api/products";                
                var res = httpClient.PostAsJsonAsync<Product>(url, item).Result;

                return res;
            }

            public static HttpResponseMessage Update(Product product)
            {
                HttpClient httpClient = new HttpClient();
                string url = $"{RootUrl}/api/products/{product.Id}";
                var res = httpClient.PutAsJsonAsync<Product>(url, product).Result;

                return res;
            }

            public static HttpResponseMessage Delete(int id)
            {
                HttpClient httpClient = new HttpClient();
                string url = $"{RootUrl}/api/products/{id}";
                var res = httpClient.DeleteAsync(url).Result;
                

                return res;

            }

        }
    }
}

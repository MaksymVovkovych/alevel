using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    internal static class HttpService
    {
        public static void GetMethod(this HttpClient client, string uri)
        {
            client.BaseAddress = new Uri(uri);

            HttpResponseMessage response = client.GetAsync("/api/products").Result;

            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(content);
            }
            else
            {
                Console.WriteLine("Request failed with status code: " + response.StatusCode);
            }
        }
        public static void GetById(this HttpClient client, string uri)
        {
            var gewg = Guid.TryParse(Console.ReadLine(), out Guid Id);
            client.BaseAddress = new Uri(uri);
            HttpResponseMessage response = client.GetAsync($"/api/products/{Id}").Result;

            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(content);
            }
            else
            {
                Console.WriteLine("Request failed with status code: " + response.StatusCode);
            }
        }
        public static void Post(this HttpClient client, string uri)
        {
            client.BaseAddress = new Uri(uri);
            var product = new Product()
            {
                Id = Guid.NewGuid(),
                Category = "magazine",
                Name = "VOGUE",
                Count = 465
            };
            var response = client.PostAsJsonAsync("/api/products", product).Result;

            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(content);
            }
            else
            {
                Console.WriteLine("Request failed with status code: " + response.StatusCode);
            }
        }
        public static void Delete(this HttpClient client, string uri)
        {
            var guid = Guid.TryParse(Console.ReadLine(), out Guid Id);
            client.BaseAddress = new Uri(uri);
            HttpResponseMessage response = client.DeleteAsync($"/api/products/{Id}").Result;

            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(content);
            }
            else
            {
                Console.WriteLine("Request failed with status code: " + response.StatusCode);
            }
        }
        public static void Update(this HttpClient client, string uri)
        {
            client.BaseAddress = new Uri(uri);
            Guid productIdToUpdate = new Guid("...");

            Product updatedProduct = new Product
            {
                Id = productIdToUpdate,
                Name = "Product",
                Category = "Category",
                Count = 20
            };

            var response = client.PutAsJsonAsync($"/api/products/{productIdToUpdate}", updatedProduct).Result;
            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(content);
            }
            else
            {
                Console.WriteLine("Request failed with status code: " + response.StatusCode);
            }
        }

    }
}

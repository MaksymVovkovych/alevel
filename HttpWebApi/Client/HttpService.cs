using System.Net.Http.Json;

namespace Client
{
    internal static class HttpService
    {
        public static async Task GetMethod(this HttpClient client)
        {
            HttpResponseMessage response = await client.GetAsync("/api/products");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);
            }
            else
            {
                Console.WriteLine("Request failed with status code: " + response.StatusCode);
            }
        }
        public static async Task GetById(this HttpClient client)
        {
            var gewg = Guid.TryParse(Console.ReadLine(), out Guid Id);

            HttpResponseMessage response = await client.GetAsync($"/api/products/{Id}");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);
            }
            else
            {
                Console.WriteLine("Request failed with status code: " + response.StatusCode);
            }
        }
        public static async Task Post(this HttpClient client)
        {
            var product = new Product()
            {
                Id = Guid.NewGuid(),
                Category = Console.ReadLine(),
                Name = Console.ReadLine(),
                Count = int.Parse(Console.ReadLine())
            };
            var response = await client.PostAsJsonAsync("/api/products", product);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);
            }
            else
            {
                Console.WriteLine("Request failed with status code: " + response.StatusCode);
            }
        }
        public static async Task Delete(this HttpClient client)
        {
            var guid = Guid.TryParse(Console.ReadLine(), out Guid Id);
            HttpResponseMessage response = await client.DeleteAsync($"/api/products/{Id}");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);
            }
            else
            {
                Console.WriteLine("Request failed with status code: " + response.StatusCode);
            }
        }
        public static async Task Update(this HttpClient client)
        {

            Guid.TryParse(Console.ReadLine(), out Guid Id);

            Product updatedProduct = new Product
            {
                Id = Id,
                Name = "Product",
                Category = "Category",
                Count = 20
            };

            var response = await client.PutAsJsonAsync($"/api/products", updatedProduct);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);
            }
            else
            {
                Console.WriteLine("Request failed with status code: " + response.StatusCode);
            }
        }

    }
}

using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MVC.Models.Enums;
using MVC.Models.Requests;
using MVC.Services.Interfaces;
using Newtonsoft.Json;

namespace MVC.Services
{
    public class HttpClientService : IHttpClientService
    {
        private readonly IHttpClientFactory _clientFactory;
        
        public HttpClientService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<TResponse> SendAsync<TResponse, TRequest>(string url, HttpMethod method, TRequest? content)
        {
            var client = _clientFactory.CreateClient();

            var httpMessage = new HttpRequestMessage
            {
                RequestUri = new Uri(url),
                Method = method
            };

            if (content != null)
            {
                var jsonContent = JsonConvert.SerializeObject(content);
                httpMessage.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            }

            var result = await client.SendAsync(httpMessage);

            if (result.IsSuccessStatusCode)
            {
                var resultContent = await result.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<TResponse>(resultContent);
                return response;
            }

            return default!;
        }
    }
}
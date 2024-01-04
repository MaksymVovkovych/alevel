using MVC.Models.Enums;
using MVC.Models.Requests;

namespace MVC.Services.Interfaces;

public interface IHttpClientService
{
    Task<TResponse> SendAsync<TResponse, TRequest>(string url, HttpMethod method, TRequest? content);
}
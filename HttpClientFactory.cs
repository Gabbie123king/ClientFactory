namespace ClientFactory;

using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net.Http.Json;

public class HttpServiceFactory : IHttpService
{
    private readonly HttpClient _httpClient;

    public HttpServiceFactory()
    {
        _httpClient = new HttpClient();

    }

    public async Task<HttpResponseMessage> Get(string accessToken, string uri)
    {
        try
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            HttpResponseMessage response = await _httpClient.GetAsync(uri);
            return response;
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Request error: {e.Message}");
            throw;
        }
    }
    public async Task<HttpResponseMessage> GetWithTime(string accessToken, string uri, TimeSpan timeout = default(TimeSpan))
    {
        try
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            HttpResponseMessage response = await _httpClient.GetAsync(uri);
            return response;
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Request error: {e.Message}");
            throw;
        }
    }
    public async Task<HttpResponseMessage> GetLims(string uri, TimeSpan timeout = default(TimeSpan))
    {
        try
        {
            HttpResponseMessage response = await _httpClient.GetAsync(uri);
            return response;
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Request error: {e.Message}");
            throw;
        }
    }

    public async Task<HttpResponseMessage> Post(string accessToken, string uri, object objValue)
    {
        try
        {
            // Set the authorization header with the provided access token
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            // Send the POST request with the object serialized as JSON
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(uri, objValue);

            // Ensure the response indicates success; otherwise, throw an exception
            response.EnsureSuccessStatusCode();

            // Return the response
            return response;
        }
        catch (HttpRequestException e)
        {
            // Log the error message to the console and rethrow the exception
            Console.WriteLine($"Request error: {e.Message}");
            throw;
        }
    }

    public async Task<HttpResponseMessage> Put(string accessToken, string uri, object objValue)
    {
        try
        {
            // Set the Authorization header
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            // Send the PUT request with JSON content
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync(uri, objValue);

            return response;
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Request error: {e.Message}");
            throw;
        }
    }

    public async Task<HttpResponseMessage> Delete(string accessToken, string uri)
    {
        try
        {
            // Set the Authorization header
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            // Send the DELETE request
            HttpResponseMessage response = await _httpClient.DeleteAsync(uri);

            // Ensure the response indicates success; otherwise, throw an exception
            response.EnsureSuccessStatusCode();
            return response;
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Request error: {e.Message}");
            throw;
        }
    }

}

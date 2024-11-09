using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebServiceTutorial.Models;

namespace WebServiceTutorial.Services;

public class JsonPlaceholderService : IJsonPlaceholderService
{
    readonly HttpClient _httpClient;

    //https://jsonplaceholder.typicode.com/posts
    public JsonPlaceholderService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IList<ExternalApiUser>> GetJsonPlaceholderAsync()
    {
        string url = "https://jsonplaceholder.typicode.com/posts";
        var result = await _httpClient.GetAsync(url);
        if (result.IsSuccessStatusCode == true)
        {
            var jsonResponse = await result.Content.ReadAsStringAsync();
            var response = JsonSerializer.Deserialize<List<ExternalApiUser>>(jsonResponse); //Follow come

            response = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ExternalApiUser>>(jsonResponse);

            return response;
        }
        return null;
    }
}

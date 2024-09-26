using System.Net.Http.Json;
using recipes_front_end.Dto;
namespace recipes_front_end.Services;

public class RecipeService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public RecipeService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public List<RecipeDto> GetRecipes()
    {
        var client = _httpClientFactory.CreateClient(Configuration.HttpClientName);
        var response = client.GetAsync("api/recipes").Result;
        if (response.IsSuccessStatusCode)
        {
            var recipes = response.Content.ReadFromJsonAsync<List<RecipeDto>>().Result;
            return recipes;
        }
        return new List<RecipeDto>();
    }
}
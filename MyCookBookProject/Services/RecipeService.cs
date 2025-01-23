using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MyCookBookProject.Models;


namespace MyCookBookProject.Services
{
    public class RecipeService
    {
        private readonly HttpClient _httpClient;
        public RecipeService(HttpClient httpClient)
        {
            _httpClient = httpClient;

        }
        public async Task<List<Recipe>> GetRecipesAsync()
        {
            var response = await
            _httpClient.GetAsync("http://localhost:5171/api/recipes");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Recipe>>(json);
        }
    }
}

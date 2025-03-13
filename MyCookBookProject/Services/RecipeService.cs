using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MyCookBookProject.Models;
using System.Text;
using MyCookBookProjectAPI.Models;


namespace MyCookBookProject.Services
{
    public class RecipeService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public RecipeService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _baseUrl = configuration["ApiSettings:BaseUrl"];
        }

        public async Task<List<Recipe>> GetRecipesAsync()
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/recipe");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Recipe>>(json);
        }

        public async Task<Recipe> GetRecipeByIDAsync(string id)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/recipe/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Recipe>(json);
        }

        public async Task<List<Recipe>> SearchRecipeAsync(RecipeSearchRequest searchRequest)
        {
            var content = new StringContent(JsonConvert.SerializeObject(searchRequest), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{_baseUrl}/Recipe/search", content);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Recipe>>(json);
        }

        public async Task<bool> AddRecipeAsync(Recipe recipe)
        {
            var json = JsonConvert.SerializeObject(recipe, Formatting.Indented); //Pretty Print for JSON readability
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            Console.WriteLine("Request Body:");
            Console.WriteLine(json);
            //var content = new StringContent(JsonConvert.SerializeObject(recipe), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{_baseUrl}/recipe", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateRecipeAsync(Recipe recipe)
        {
            if (string.IsNullOrWhiteSpace(recipe.recipeID))
            {
                return false;
            }

            var encodedID = Uri.EscapeDataString(recipe.recipeID);
            var content = new StringContent(JsonConvert.SerializeObject (recipe), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"{_baseUrl}/recipe/{encodedID}", content);
            return response.IsSuccessStatusCode;
        }


    }
}
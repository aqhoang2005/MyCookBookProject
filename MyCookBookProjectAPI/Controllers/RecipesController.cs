using Microsoft.AspNetCore.Mvc;
using MyCookBookProjectAPI.Models;

namespace MyCookBookProjectAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class RecipesController : ControllerBase
    {
        private static readonly List<Recipe> _recipes = new List<Recipe>()
        {
             new Recipe { name = "Pasta", Ingredients = new List<string> { "Pasta", "Tomato Sauce" }, Steps = "Boil pasta." },
             new Recipe { name = "Salad", Ingredients = new List<string> { "Lettuce", "Tomatoes" }, Steps = "Mix all ingredients." },
             new Recipe { name = "Egg Fried Rice", Ingredients = new List<string> {"Rice, Meat of Choice, Eggs, Oil, Onions, Garlic"}, Steps = "Stir ingredients together on an oventop." }

        };

        [HttpGet]
        public IActionResult GetRecipes()
        {
            return Ok(_recipes);
        }

        [HttpPost("search")]
        public IActionResult Search([FromBody] RecipeSearchRequest request)
        {
            // Check if the request body is null or if Query is empty
            if (request == null || string.IsNullOrWhiteSpace(request.Query))
            {
                return BadRequest(new { error = "Query cannot be empty." });
            }

            Console.WriteLine($"[DEBUG] Query: {request.Query}");

            // Filter the recipes based on the query
            var results = _recipes
                .Where(r => r.name.Contains(request.Query, StringComparison.OrdinalIgnoreCase))
                .ToList();

            return Ok(results);  // Return the filtered recipe results
        }



        [HttpPost("test")]
        public IActionResult Test([FromBody] object requestBody)
        {
            Console.WriteLine($"[DEBUG] Raw Request: {requestBody}");
            return Ok(requestBody);
        }
    }
}

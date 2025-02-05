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
            if (string.IsNullOrWhiteSpace(request.Query))
            {
                return BadRequest("Query cannot be empty.");
            }
            var results = Recipe.Where(r => r.Name.Contains(rquest.Query,System.StringComparison.OrdinalIgnoreCase)).ToList();
            return Ok(results);
        
        
        
        
        }

    }
}

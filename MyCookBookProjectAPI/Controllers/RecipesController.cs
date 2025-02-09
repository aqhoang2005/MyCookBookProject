using Microsoft.AspNetCore.Mvc;
using MyCookBookProjectAPI.Models;

[ApiController]
[Route("api/[controller]")]

public class RecipeController : ControllerBase
{
    private static readonly List<Recipe> Recipes = new List<Recipe>
    {
        new Recipe{name = "Pasta", Ingredients = new List<string> {"Pasta", "Tomato Sauce" }, Steps = "Boil pasta and mix with sauce." },
        new Recipe{name = "Salad", Ingredients = new List<string> {"Lettuce", "Tomatoes", "Cucumbers" }, Steps = "Chop and mix ingredients." },
        new Recipe{name = "Fried Rice", Ingredients = new List<string> {"Rice", "Eggs", "Meat" }, Steps = "Cook rice and mix with meat and eggs in pan." }

    };

    [HttpGet]
    public IActionResult GetRecipes()
    {
        return Ok(Recipes);
    }

    [HttpPost("search")]
    public IActionResult Search([FromBody] RecipeSearchRequest request)
    {
        if (request == null)
        {
            return BadRequest("Request body is null.");
        }

        if (string.IsNullOrWhiteSpace(request.Query))
        {
            return BadRequest("Query cannot be empty.");
        }

        var results = Recipes
            .Where(r => r.name.Contains(request.Query, System.StringComparison.OrdinalIgnoreCase))
            .ToList();

        return Ok(results);
    }
}
using Microsoft.AspNetCore.Mvc;
using MyCookBookProjectAPI.Models;

[ApiController]
[Route("api/[controller]")]

public class RecipeController : ControllerBase
{
    private readonly IRecipeService _recipeService;

    public RecipeController(IRecipeService recipeService)
    {
        _recipeService = recipeService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Recipe>> GetAllRecipe()
    {
        return _recipeService.GetAllRecipes();
    }

    [HttpGet("{id}")]
    public ActionResult<Recipe> GetRecipeByID(string id)
    {
        var recipe = _recipeService.GetRecipeByID(id);
        if (recipe == null)
        {
            return NotFound();
        }
        return Ok(recipe);
    }

    [HttpPost("search")]
    public ActionResult<IEnumerable<Recipe>> SearchRecipes([FromBody]RecipeSearchRequest searchRequest)
    {
        if (searchRequest == null)
        {
            return BadRequest("Invalid search request.");
        }

        searchRequest.Categories ?? = new List<string>();

        var recipes = _recipeService.SearchRecipes(searchRequest);
        return Ok(recipes);
    }


    [HttpPost]
    public ActionResult<Recipe> CreateRecipe([FromBody] Recipe recipe)
    {
        if (recipe == null || string.IsNullOrWhiteSpace(recipe.name))
        {
            return BadRequest("Invalid recipe data.");
        }

        recipe.recipeID = Guid.NewGuid().ToString();

        _recipeService.AddRecipe(recipe);
        return CreatedAtAction(nameof(GetRecipeByID), new { id = recipe.recipeID }, recipe);
    }
}

using Microsoft.AspNetCore.Mvc;
using MyCookBookProject.Services;
using MyCookBookProject.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using MyCookBookProjectAPI.Models;


namespace MyCookBookProject.Controllers
{
    [ApiController]
    [Route("Recipe")]
    public class RecipeController : Controller
    {
        private readonly RecipeService _recipeService;

        public RecipeController(RecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        //Shows Recipe Index Page
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        //Fetch all recipes (Get /Recipe/GetAll)
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllRecipes()
        {
            var recipes = await _recipeService.GetRecipesAsync();
            return Json(recipes);
        }

        //Fetch recipe by ID (GET /Recipe/{id})
        [HttpGet("{id}")]
        public  async Task <IActionResult> GetRecipeByID(string id)
        {
            var recipe = await _recipeService.GetRecipeByIDAsync(id);
            if (recipe == null)
            {
                return NotFound(new {success = false, message = "Recipe not found."});
            }
            return Json(recipe);
        }

        //Search for Recipes (POST /Recipe/Search)
        [HttpPost("Search")]
        public async Task<IActionResult> SearchRecipes([FromBody] RecipeSearchRequest searchRequest)
        {
            // searchRequest.categoryType = new List<categoryType>();
            var recipes = await _recipeService.SearchRecipeAsync(searchRequest);
            return Json(recipes);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddRecipe([FromBody] Recipe recipe)
        {
            Console.WriteLine("Received Recipe: " + JsonConvert.SerializeObject(recipe));

            //TODO: Add Validation
           /* if (recipe == null || string.IsNullOrWhiteSpace(recipe.name) || recipe.ingredients == null || recipe.ingredients.Count == 0
                || recipe.instructions == null || recipe.instructions.Count == 0 || string.IsNullOrWhiteSpace(recipe.summary) || recipe.Categories == null)
            {
                return BadRequest(new { success = false, message = "Invalid recipe data" });
            }*/

            bool added = await _recipeService.AddRecipeAsync(recipe);
            return Json(new { success = added, message = added ? "Recipe added successfully." : "Failed to add recipe." });

        }

        [HttpPut("Edit/{id}")]
        public async Task<IActionResult> EditRecipe(string id, [FromBody] Recipe recipe)
        {
            if (recipe == null || string.IsNullOrWhiteSpace(recipe.name)
                || recipe.ingredients == null || recipe.ingredients.Count == 0 ||
                recipe.instructions == null || recipe.instructions.Count == 0 
                || string.IsNullOrWhiteSpace(recipe.summary) || recipe.Categories == null)
            {
                return BadRequest(new { success = false, message = "Invalid recipe data" });
            }

            bool updated = await _recipeService.UpdateRecipeAsync(recipe);
            return Json(new { success = updated, message = updated ? "Recipe updated successfully" : "Failed to update recipe." });

        }


    }
}
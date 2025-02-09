using Microsoft.AspNetCore.Mvc;
using MyCookBookProject.Services;
using System.Threading.Tasks;
using System.Text;


namespace MyCookBookProject.Controllers
{
    public class RecipeController : Controller
    {
        private readonly RecipeService _recipeService;

        public RecipeController(RecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        public async Task<IActionResult> Index()
        {
            var recipes = await _recipeService.GetRecipesAsync();
            return View(recipes);
        }

        // Search action to fetch filtered recipes
        public async Task<IActionResult> Search(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return RedirectToAction("Index");
            }
            var recipes = await _recipeService.SearchRecipesAsync(query);
            return View("Index", recipes);
        }
    }
}
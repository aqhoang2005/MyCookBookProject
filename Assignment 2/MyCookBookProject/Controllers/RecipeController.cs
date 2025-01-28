using Microsoft.AspNetCore.Mvc;
using MyCookBookProject.Services;
using System.Threading.Tasks;


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
    }
}

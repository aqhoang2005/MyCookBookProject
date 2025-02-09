using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyCookBookProject.Models;
using MyCookBookProject.Services;

namespace MyCookBookProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly RecipeService _recipeService;
        public HomeController(ILogger<HomeController> logger, RecipeService recipeService)
        {
            _logger = logger;
            _recipeService = recipeService;
        }
/*
        public async Task<IActionResult> Index()
        {
            var recipes = await _recipeService.GetRecipesAsync();
            return View(recipes);
        }*/

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AboutMe()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

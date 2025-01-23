using Microsoft.AspNetCore.Mvc;
using MyCookBookProjectAPI.Models;

namespace MyCookBookProjectAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class RecipesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetRecipes()
        {
            return Ok(new List<Recipe>
            {
             new Recipe { name = "Pasta", Ingredients = new List<string> { "Pasta", "Tomato Sauce" }, Steps = "Boil pasta." },
             new Recipe { name = "Salad", Ingredients = new List<string> { "Lettuce", "Tomatoes" }, Steps = "Mix all ingredients." }


            });
        }
        
    }
}

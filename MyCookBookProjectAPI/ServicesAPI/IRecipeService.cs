using MyCookBookProjectAPI.Models;
using System.Collections.Generic;

namespace MyCookBookProjectAPI.ServicesAPI
{
    public interface IRecipeService
    {
        List<Recipe> GetAllRecipes();
        Recipe GetRecipeByID(string id);
        List<Recipe> SearchRecipes(RecipeSearchRequest request);
        void AddRecipe(Recipe recipe);
        bool UpdateRecipe(string id, Recipe recipe);
        bool DeleteRecipe(string id);
    }
}

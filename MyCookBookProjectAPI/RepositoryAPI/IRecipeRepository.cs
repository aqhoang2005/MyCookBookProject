using MyCookBookProjectAPI.Models;
using System.Collections.Generic;

namespace MyCookBookProjectAPI.RepositoryAPI
{
    public interface IRecipeRepository
    {
        List<RecipeController> GetAllRecipes();
        RecipeController GetRecipeByID(string id);
        List<RecipeController> SearchRecipes(RecipeSearchRequest searchRequest);
        void AddRecipe(Recipe recipe);
        bool UpdateRecipe(string id, Recipe recipe);
        bool DeleteRecipe(string id);
    }
}

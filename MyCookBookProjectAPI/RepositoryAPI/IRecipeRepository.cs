using MyCookBookProjectAPI.Models;
using System.Collections.Generic;

namespace MyCookBookProjectAPI.RepositoryAPI
{
    public interface IRecipeRepository
    {
        List<Recipe> GetAllRecipes();
        Recipe GetRecipeByID(string id);
        List<Recipe> SearchRecipes(RecipeSearchRequest searchRequest);
        void AddRecipe(Recipe recipe);
        bool UpdateRecipe(string id, Recipe updatedRecipe);
        bool DeleteRecipe(string id);
    }
}

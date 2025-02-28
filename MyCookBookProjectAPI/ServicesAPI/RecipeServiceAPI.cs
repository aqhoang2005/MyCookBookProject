using MyCookBookProjectAPI.Models;
using MyCookBookProjectAPI.RepositoryAPI;
using System.Collections.Generic;

namespace MyCookBookProjectAPI.ServicesAPI
{
    public class RecipeServiceAPI :IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;

        public RecipeServiceAPI(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        public List<Recipe> GetAllRecipes() => _recipeRepository.GetAllRecipes();
        public Recipe GetRecipeByID(string id) => _recipeRepository.GetRecipeByID(id);
        public List<Recipe> SearchRecipes(RecipeSearchRequest searchRequest) => _recipeRepository.SearchRecipes(searchRequest);
        public void AddRecipe(Recipe recipe) => _recipeRepository.AddRecipe(recipe);
        public bool UpdateRecipe(string id, Recipe recipe) => _recipeRepository.UpdateRecipe(id, recipe);

        public bool DeleteRecipe(string id) => _recipeRepository.DeleteRecipe(id);

    }
}

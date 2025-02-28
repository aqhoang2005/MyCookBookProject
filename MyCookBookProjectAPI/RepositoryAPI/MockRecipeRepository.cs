using Microsoft.AspNetCore.Mvc.Formatters;
using MyCookBookProjectAPI.Models;
using System.Collections.Generic;
using System.Linq;


namespace MyCookBookProjectAPI.RepositoryAPI
{
    public class MockRecipeRepository
    {
        private readonly List<Recipe> _recipes = new()
        {
            new Recipe
            {
                recipeID = Guid.NewGuid().ToString(),
                name = "Pasta",
                tagLine = "Classic Italian Dish",
                summary = "A simple, delicious pasta dish with tomato sauce.",
                ingredients = new List<string>
                {
                    "Pasta",
                    "Tomato Sauce",
                    "Meatballs"
                },
                instructions = new List<string>
                {
                    "Boil the water and cook pasta until al dente.",
                    "Heat tomato sauce and cook meatballs in separate pans.",
                    "Mix pasta with sauce and meatballs and serve hot."
                },
                Categories = new List<CategoryType>()
                {
                    CategoryType.Dinner, CategoryType.Vegetarian
                },
                Media = null
            },

            new Recipe
            {
                recipeID = Guid.NewGuid().ToString(),
                name = "Salad",
                tagLine = "Fresh and Healthy",
                summary = "A light and refreshing salad made with fresh vegetables.",
                ingredients = new List<string>
                {
                    "Lettuce",
                    "Cucumbers",
                    "Tomatoes"
                },
                instructions = new List<string>
                {
                    "Wash and chop all vegetables.",
                    "Mix them all into a bowl and toss with dressing.",
                    "Serve fresh."
                },
                Categories = new List<CategoryType>()
                {
                    CategoryType.Lunch, CategoryType.Vegetarian, CategoryType.Vegan
                },
                Media = null
            },

             new Recipe
            {
                recipeID = Guid.NewGuid().ToString(),
                name = "Omlette",
                tagLine = "Filling Breakfast Option",
                summary = "A fluffy and delicious egg omelette.",
                ingredients = new List<string>
                {
                    "Eggs",
                    "Milk",
                    "Cheese"
                },
                instructions = new List<string>
                {
                    "Crack the eggs and beat them with milk in a bowl.",
                    "Heat a pan and pour the mixture inside.",
                    "Add cheese, cook until firm, and fold."
                },
                Categories = new List<CategoryType>()
                {
                    CategoryType.Breakfast, CategoryType.HighProtein
                },
                Media = null
            },

        };

        public List<Recipe> GetAllRecipes() => _recipes;
        public Recipe GetRecipeByID(string id) => _recipes.FirstOrDefault(r => r.recipeID == id);
        public List<Recipe> SearchRecipes(RecipeSearchRequest searchRequest)
        {
            return _recipes
                .Where(r => (string.IsNullOrEmpty(searchRequest.keyWord) ||
                r.name.Contains(searchRequest.keyWord, StringComparison.OrdinalIgnoreCase) ||
                r.summary.Contains(searchRequest.keyWord, StringComparison.OrdinalIgnoreCase)) &&
                ((searchRequest.categoryTypes == null || searchRequest.categoryTypes.Count == 0) ||
                r.Categories.Any(c=> searchRequest.categoryTypes.Contains(c)))
                )
                .ToList();
        }

        public void AddRecipe(Recipe recipe)
        {
            if (string.IsNullOrEmpty(recipe.name) || recipe.ingredients == null || !recipe.ingredients.Any())
            {
                throw new System.ArgumentException("Invalid recipe data");
            }
            _recipes.Add(recipe);
        }

        public bool UpdateRecipe(string id, Recipe updatedRecipe)
        {
            var index = _recipes.FindIndex(r => r.recipeID == id);
            if (index == -1) return false;
            return true;
        }

    }
}

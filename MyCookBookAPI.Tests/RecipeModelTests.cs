using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using MyCookBookProjectAPI.Models;

namespace MyCookBookAPI.Tests
{
    public class RecipeModelTests
    {
        [Fact]
        public void RecipeModel_ShouldStoreDataCorrectly()
        {
            // Arrange
            var recipe = new Recipe
            {
                name = "Pasta",
                Ingredients = new List<string> { "Pasta", "Tomato Sauce" },
                Steps = "Boil pasta."
            };
            // Assert
            Assert.Equal("Pasta", recipe.name);
            Assert.Contains("Tomato Sauce", recipe.Ingredients);
            Assert.Equal("Boil pasta.", recipe.Steps);
        }
    }
}

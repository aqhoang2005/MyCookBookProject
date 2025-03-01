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
                ingredients = new List<string> { "Pasta", "Tomato Sauce" },
            };
            // Assert
            Assert.Equal("Pasta", recipe.name);
            Assert.Contains("Tomato Sauce", recipe.ingredients);
        }
    }
}

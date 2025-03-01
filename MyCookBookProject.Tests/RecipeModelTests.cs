using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using MyCookBookProject.Models;

namespace MyCookBookProject.Tests
{
    public class RecipeModelTests
    {
        [Fact]
        public void RecipeModel_ShouldStoreDataCorrectly()
        {
            //Arrange
            var recipe = new Recipe
            {
                name = "Salad",
                ingredients = new List<string> { "Lettuce", "Tomatoes", "Dressing" },
            };

            //Assert
            Assert.Equal("Salad", recipe.name);
            Assert.Contains("Tomatoes", recipe.ingredients);
        }
    }
}

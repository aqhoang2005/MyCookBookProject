using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using MyCookBookProjectAPI.Controllers;
using MyCookBookProjectAPI.RepositoryAPI;
using MyCookBookProjectAPI.ServicesAPI;

public class RecipeServiceTest
{
    private readonly RecipeServiceAPI _recipeService;

    public RecipeServiceTest()
    {
        _recipeService = new RecipeServiceAPI(new MockRecipeRepository());
    }

    [Fact]
    public void GetAllRecipes_ShouldReturnNonEmptyList()
    {
        //Act
        var recipes = _recipeService.GetAllRecipes();

        //Assert
        Assert.NotEmpty(recipes);
    }

    [Fact]
    public void GetRecipeByID_ShouldReturnCorrectRecipe()
    {
        //Arrange
        var recipeID = _recipeService.GetAllRecipes()[0].recipeID;
        
        //Act
        var recipe = _recipeService.GetRecipeByID(recipeID);

        //Assert
        Assert.NotNull(recipe);
        Assert.Equal(recipeID, recipe.recipeID);
    }



}
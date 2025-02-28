using Microsoft.AspNetCore.Mvc;
using MyCookBookProjectAPI.ServicesAPI;
using MyCookBookProjectAPI.Models;
using Xunit;
using Moq;
using System.Collections.Generic;
using MyCookBookProjectAPI.RepositoryAPI;
using System.Security.Cryptography.X509Certificates;

public class RecipeControllerTest
{
    private readonly RecipeController _controller;
    private readonly Mock<IRecipeService> _mockService;

    public RecipeControllerTest()
    {
        _mockService = new Mock<IRecipeService>();
        _controller = new RecipeController(_mockService.Object);
    }

    [Fact]
    public void GetAllRecipes_ReturnsOkResult()
    {
        //Arrange
        var fakeRecipes = new List<Recipe>() { new Recipe { recipeID = "1", name = "Test" } }; 
        _mockService.Setup(s => s.GetAllRecipes()).Returns(fakeRecipes);

        //Act
        var result = _controller.GetAllRecipe();

        //Assert
        var actionResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnRecipes = Assert.IsType<List<Recipe>>(actionResult.Value);
        Assert.Single(returnRecipes);
    }


    [Fact]
    public void GetRecipeByID_WhenRecipeExists_ReturnsOk()
    {
        //Arrange
        var fakeRecipes = new Recipe { recipeID = "123", name = "Pasta" };
        _mockService.Setup(s => s.GetRecipeByID("123")).Returns(fakeRecipes);

        //Act
        var result = _controller.GetRecipeByID("123");

        //Assert
        var actionResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnedRecipe = Assert.IsType<Recipe>(actionResult.Value);
        Assert.Equal("123", returnedRecipe.recipeID);
    }


    [Fact]
    public void GetRecipeByID_WhenRecipeDoesNotExist_ReturnsNotFound()
    {
        //Arrange
        _mockService.Setup(s => s.GetRecipeByID("999")).Returns((Recipe)null);

        //Act
        var result = _controller.GetRecipeByID("999");

        //Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }
}


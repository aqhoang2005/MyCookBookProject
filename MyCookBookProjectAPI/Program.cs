using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json.Serialization;

using MyCookBookProjectAPI.Models;
using MyCookBookProjectAPI.ServicesAPI;
using MyCookBookProjectAPI.RepositoryAPI;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true; // Disable automatic validation
    });

builder.Services.AddSingleton<IRecipeRepository, MockRecipeRepository>();
builder.Services.AddScoped<IRecipeService, RecipeServiceAPI>();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
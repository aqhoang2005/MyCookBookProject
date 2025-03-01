using MyCookBookProject.Models;
using System.Text.Json.Serialization;

namespace MyCookBookProject.Models
{
    public class Recipe
    {
        public string recipeID { get; set; }
        public string name { get; set; }
        public string tagLine { get; set; }
        public string summary { get; set; }
        public List<string> instructions { get; set; } = new List<string>();
        public List<string> ingredients { get; set; } = new List<string>();

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<CategoryType>? Categories { get; set; } = new List<CategoryType>();

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<RecipeMedia>? Media { get; set; } = new List<RecipeMedia>();

        public Recipe() { }

    }
}

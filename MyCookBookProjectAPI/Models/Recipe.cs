using System.Text.Json.Serialization;
using Google.Cloud.Firestore;

namespace MyCookBookProjectAPI.Models
{
    [FirestoreData]
    public class Recipe
    {
        [FirestoreProperty] public string recipeID { get; set; }
        [FirestoreProperty] public string name { get; set; }
        [FirestoreProperty] public string tagLine { get; set; }
        [FirestoreProperty] public string summary { get; set; }
        [FirestoreProperty] public List<string> instructions { get; set; } = new List<string>();
        [FirestoreProperty] public List<string> ingredients { get; set; } = new List<string>();

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [FirestoreProperty] public List<CategoryType>? Categories { get; set; } = new List<CategoryType>();

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [FirestoreProperty] public List<RecipeMedia>? Media { get; set; } = new List<RecipeMedia>();

        public Recipe() { }

    }
}

using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;
using MyCookBookProjectAPI.Models;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyCookBookProjectAPI.RepositoryAPI
{
    public class FirebaseDBRecipeRepository : IRecipeRepository
    {
        private readonly FirestoreDb _firestoreDB;
        private const string CollectionName = "Recipes";

        public FirebaseDBRecipeRepository()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wwwroot", "mycookbookprojectdb-firebase-adminsdk-fbsvc-eb153278f3.json");

            if (!File.Exists(path))
            {
                throw new FileNotFoundException("Firebase service account key not found.", path);
            }

            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS" , path);
            _firestoreDB = FirestoreDb.Create("mycookbookprojectdb");

        }

        public List<Recipe> GetAllRecipes()
        {
            return GetAllRecipesAsync().GetAwaiter().GetResult();
        }

        public Recipe GetRecipeByID(string id)
        {
            return GetRecipeByIDAsync(id).GetAwaiter().GetResult();
        }

        public List<Recipe> SearchRecipes(RecipeSearchRequest searchRequest)
        {
            return SearchRecipesAsync(searchRequest).GetAwaiter().GetResult();
        }
        public void AddRecipe(Recipe recipe)
        {
            AddRecipeAsync(recipe).GetAwaiter().GetResult();
        }
        public bool UpdateRecipe(string id, Recipe updatedRecipe)
        {
            return UpdateRecipeAsync(id, updatedRecipe).GetAwaiter().GetResult();
        }
        public bool DeleteRecipe(string id)
        {
            return DeleteRecipeAsync(id).GetAwaiter().GetResult();
        }

        // � Get All Recipes
        private async Task<List<Recipe>> GetAllRecipesAsync()
        {
            Query query = _firestoreDB.Collection(CollectionName);
            QuerySnapshot snapshot = await query.GetSnapshotAsync();
            return snapshot.Documents
            .Select(doc => doc.ConvertTo<Recipe>())
            .ToList();
        }
        // � Get Recipe by ID
        private async Task<Recipe> GetRecipeByIDAsync(string id)
        {
            DocumentSnapshot snapshot = await
           _firestoreDB.Collection(CollectionName).Document(id).GetSnapshotAsync();
            return snapshot.Exists ? snapshot.ConvertTo<Recipe>() : null;
        }

        //Search Recipes
        private async Task <List<Recipe>> SearchRecipesAsync(RecipeSearchRequest searchRequest)
        {
            Query query = _firestoreDB.Collection(CollectionName);
            QuerySnapshot snapshot = await query.GetSnapshotAsync();

            return snapshot.Documents
             .Select(doc => doc.ConvertTo<Recipe>())
             .Where(r => string.IsNullOrEmpty(searchRequest.keyWord)
            || r.name.Contains(searchRequest.keyWord, StringComparison.OrdinalIgnoreCase)
            || r.summary.Contains(searchRequest.keyWord,StringComparison.OrdinalIgnoreCase))
           .ToList();
        }

        //Add Recipe
        private async Task AddRecipeAsync(Recipe recipe)
        {
            if (recipe == null || string.IsNullOrWhiteSpace(recipe.recipeID))
            {
                throw new ArgumentException("Invalid recipe data: Recipe ID cannot be null.");
            }

            DocumentReference docRef =
            _firestoreDB.Collection(CollectionName).Document(recipe.recipeID);
            await docRef.SetAsync(recipe);
        }

        //Update Recipe
        private async Task<bool> UpdateRecipeAsync(string id, Recipe updatedRecipe)
        {
            if (updatedRecipe == null) return false;
            DocumentReference docRef = _firestoreDB.Collection(CollectionName).Document(id);
            DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();
            if (!snapshot.Exists) return false;
            Dictionary<string, object> updateData = new()
            {
                { "Name", updatedRecipe.name },
                { "TagLine", updatedRecipe.tagLine },
                { "Summary", updatedRecipe.summary },
                { "Ingredients", updatedRecipe.ingredients ?? new List<string>() },
                { "Instructions", updatedRecipe.instructions ?? new List<string>() },
                { "Categories", updatedRecipe.Categories?.Select(c => c.ToString()).ToList() ?? new List<string>() },
                { "Media", updatedRecipe.Media != null ? updatedRecipe.Media.Select(m => new Dictionary<string, object>
                 {
                    { "Url", m.Url },
                    { "Type", m.Type },
                     { "Order", m.Order }
                 }).ToList() : new List<Dictionary<string, object>>() }
             };
            await docRef.UpdateAsync(updateData);
            return true;

        }

        //Delete Recipe
        private async Task<bool> DeleteRecipeAsync(string id)
        {
            DocumentReference docRef = _firestoreDB.Collection(CollectionName).Document(id);
            DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();

            if(!snapshot.Exists) return false;

            await docRef.DeleteAsync();
            return true;
        }

    }
}

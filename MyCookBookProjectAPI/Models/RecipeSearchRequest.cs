using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyCookBookProjectAPI.Models
{
    public class RecipeSearchRequest : ControllerBase
    {
        public string Query { get; set; }
    }
}

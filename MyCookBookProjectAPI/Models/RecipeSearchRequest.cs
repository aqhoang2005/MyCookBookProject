using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
namespace MyCookBookProjectAPI.Models
{
    public class RecipeSearchRequest : ControllerBase
    {
        [Required(ErrorMessage = "Query field is required.")]
        public string Query { get; set; }
    }
}

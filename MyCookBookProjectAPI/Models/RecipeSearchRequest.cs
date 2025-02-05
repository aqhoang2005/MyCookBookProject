using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyCookBookProjectAPI.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeSearchRequest : ControllerBase
    {
        public string Query { get; set; }
    }
}

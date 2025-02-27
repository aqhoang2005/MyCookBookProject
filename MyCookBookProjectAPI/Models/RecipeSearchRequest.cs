﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
namespace MyCookBookProjectAPI.Models
{
    public class RecipeSearchRequest : ControllerBase
    {
      public string keyWord { get; set; }
        public List<CategoryType> categoryTypes { get; set; }= new List<CategoryType>();
    }
}

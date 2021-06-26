using Microsoft.AspNetCore.Mvc;
using Services;
using Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITopicTwister.Controllers
{
    public class CategoryController : Controller
    {
        [HttpGet("GetRandomCategories")]
        public List<CategoryDTO> GetRandomCategories()
        {
            CategoryService categoryService = new CategoryService();
            List<CategoryDTO> categoryDTO = categoryService.GetRandomCategories(3);
            return categoryDTO;
        }

        [HttpGet("GetRandomCategory")]
        public CategoryDTO GetRandomCategory()
        {
            CategoryService categoryService = new CategoryService();
            List<CategoryDTO> categoryDTO = categoryService.GetRandomCategories(3);
            return categoryDTO[0];
        }
    }
}

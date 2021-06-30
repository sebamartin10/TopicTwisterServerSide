using Microsoft.AspNetCore.Mvc;
using Services;
using Services.DTOs;
using Services.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITopicTwister.Controllers
{
    public class CategoryController : Controller
    {
        [HttpGet("CreateCategory")]
        public ResponseTopicTwister<CategoryDTO> CreateCategory(CategoryDTO categoryDTO)
        {
            CategoryService categoryService = new CategoryService();
            ResponseTopicTwister<CategoryDTO> response = categoryService.CreateCategory(categoryDTO.CategoryName);
            return response;
        }

        [HttpGet("GetRandomCategories")]
        public ResponseTopicTwister<List<CategoryDTO>> GetRandomCategories()
        {
            CategoryService categoryService = new CategoryService();
            ResponseTopicTwister<List<CategoryDTO>> response = categoryService.GetRandomCategories(3);
            return response;
        }

        //[HttpGet("GetRandomCategory")]
        //public CategoryDTO GetRandomCategory()
        //{
        //    CategoryService categoryService = new CategoryService();
        //    List<CategoryDTO> categoryDTO = categoryService.GetRandomCategories(3);
        //    return categoryDTO[0];
        //}
    }
}

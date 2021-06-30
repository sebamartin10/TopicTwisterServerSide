using Microsoft.AspNetCore.Mvc;
using Repository.Repos;
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
            CategoryService categoryService = new CategoryService(new CategoryRepository());
            ResponseTopicTwister<CategoryDTO> response = categoryService.CreateCategory(categoryDTO.CategoryName);
            return response;
        }

        [HttpGet("GetRandomCategories")]
        public ResponseTopicTwister<List<CategoryDTO>> GetRandomCategories()
        {
            CategoryService categoryService = new CategoryService(new CategoryRepository());
            ResponseTopicTwister<List<CategoryDTO>> response = categoryService.GetRandomCategories(3);
            return response;
        }

    }
}

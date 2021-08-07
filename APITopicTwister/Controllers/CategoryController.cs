using Microsoft.AspNetCore.Mvc;
using Models;
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
        private readonly ContextDB contexto;

        public CategoryController(ContextDB contexto) {
            this.contexto = contexto;
        }
        [HttpPost("CreateCategory")]
        public ResponseTopicTwister<CategoryDTO> CreateCategory(CategoryDTO categoryDTO)
        {
            CategoryService categoryService = new CategoryService(contexto);
            ResponseTopicTwister<CategoryDTO> response = categoryService.CreateCategory(categoryDTO.CategoryName);
            return response;
        }

        [HttpGet("GetRandomCategories")]
        public ResponseTopicTwister<List<CategoryDTO>> GetRandomCategories()
        {
            CategoryService categoryService = new CategoryService(contexto);
            ResponseTopicTwister<List<CategoryDTO>> response = categoryService.GetRandomCategories(5);
            return response;
        }

        [HttpGet("GetAllCategories")]
        public ResponseTopicTwister<List<CategoryDTO>> GetAllCategories()
        {
            CategoryService categoryService = new CategoryService(contexto);
            ResponseTopicTwister<List<CategoryDTO>> response = categoryService.GetAllCategories();
            return response;
        }

    }
}

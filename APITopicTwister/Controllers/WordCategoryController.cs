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
    public class WordCategoryController : Controller
    {
        private readonly ContextDB contexto;

        public WordCategoryController(ContextDB contexto) {
            this.contexto = contexto;
        }
        [HttpPost("CreateWordCategory")]
        public ResponseTopicTwister<WordCategoryDTO> CreateWordCategory(string categoryName, string wordName)
        {
            WordCategoryService wordCategoryService = new WordCategoryService(contexto);
            ResponseTopicTwister<WordCategoryDTO> response = wordCategoryService.CreateWordCategory(categoryName, wordName);
            return response;
        }


    }
}

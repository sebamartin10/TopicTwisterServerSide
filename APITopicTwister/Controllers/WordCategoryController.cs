﻿using Microsoft.AspNetCore.Mvc;
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
        [HttpPost("CreateWordCategory")]
        public ResponseTopicTwister<WordCategoryDTO> CreateWordCategory(string categoryName, string wordName)
        {
            WordCategoryService wordCategoryService = new WordCategoryService();
            ResponseTopicTwister<WordCategoryDTO> response = wordCategoryService.CreateWordCategory(categoryName, wordName);
            return response;
        }


    }
}

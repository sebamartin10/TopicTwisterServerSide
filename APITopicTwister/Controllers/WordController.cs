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
    public class WordController : Controller
    {
        [HttpPost("CreateWord")]
        public ResponseTopicTwister<WordDTO> CreateWord(WordDTO wordDTO)
        {
            WordService wordService = new WordService();
            ResponseTopicTwister<WordDTO> response = wordService.CreateWord(wordDTO.WordName);
            return response;
        }


    }
}
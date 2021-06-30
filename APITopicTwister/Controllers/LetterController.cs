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
    public class LetterController: Controller
    {
        [HttpGet("CreateLetter")]
        public ResponseTopicTwister<LetterDTO> CreateCategory(LetterDTO letterDTO)
        {
            LetterService letterService = new LetterService();
            ResponseTopicTwister<LetterDTO> response = letterService.CreateLetter(letterDTO.LetterName);
            return response;
        }

        [HttpGet("GetRandomLetter")]
        public ResponseTopicTwister<LetterDTO> GetRandomLetter()
        {
            LetterService letterService = new LetterService();
            ResponseTopicTwister<LetterDTO> response = letterService.GetRandomLetter();
            return response;
        }
    }
}

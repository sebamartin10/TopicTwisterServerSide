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
    public class LetterController: Controller
    {
        private readonly ContextDB contexto;

        public LetterController(ContextDB contexto) {
            this.contexto = contexto;
        }
        [HttpPost("CreateLetter")]
        public ResponseTopicTwister<LetterDTO> CreateCategory(LetterDTO letterDTO)
        {
            LetterService letterService = new LetterService(contexto);
            ResponseTopicTwister<LetterDTO> response = letterService.CreateLetter(letterDTO.LetterName);
            return response;
        }

        [HttpGet("GetRandomLetter")]
        public ResponseTopicTwister<LetterDTO> GetRandomLetter()
        {
            LetterService letterService = new LetterService(contexto);
            ResponseTopicTwister<LetterDTO> response = letterService.GetRandomLetter();
            return response;
        }

        [HttpGet("GetAllLetters")]
        public ResponseTopicTwister<List<LetterDTO>> GetAllLetters()
        {
            LetterService letterService = new LetterService(contexto);
            ResponseTopicTwister<List<LetterDTO>> response = letterService.GetAllLetters();
            return response;
        }
    }
}

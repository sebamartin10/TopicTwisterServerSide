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
    public class AnswerController : Controller
    {
        private readonly ContextDB contexto;
        public AnswerController(ContextDB contexto) {
            this.contexto = contexto;
        }
        [HttpPost("CreateAnswer")]
        public ResponseTopicTwister<AnswerDTO> CreateAnswer(string wordAnswered, CategoryDTO categoryDTO, LetterDTO letterDTO, TurnDTO turnDTO)
        {
            AnswerService answerService = new AnswerService(contexto);
            ResponseTopicTwister<AnswerDTO> response = answerService.CreateAnswer(wordAnswered, categoryDTO.CategoryName, letterDTO.LetterName, turnDTO.TurnID);
            return response;
        }

        //[HttpGet("GetResultAnswer")]
        //public ResponseTopicTwister<List<AnswerDTO>> GetResultAnswer()
        //{
        //    AnswerService answerService = new AnswerService();
        //    ResponseTopicTwister<AnswerDTO> response = answerService.GetResultAnswer();
        //    return response;
        //}
    }
}

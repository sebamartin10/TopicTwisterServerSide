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
    [ApiController]
    public class TurnController : Controller
    {
        private readonly ContextDB contexto;

        public TurnController(ContextDB contexto) {
            this.contexto = contexto;
        }
        [HttpPost("turn/{turnID}/finish")]
        public ResponseTopicTwister<TurnDTO> FinishTurn(string turnId, FinishTurnDTO finishTurnDTO)
        {
            TurnService turnService = new TurnService(contexto);
            List<string> words = new List<string>();
            List<string> categoriesIDs = new List<string>();
            finishTurnDTO.WordCategories.ForEach(wc=> {
                words.Add(wc.Word);
                categoriesIDs.Add(wc.CategoryID);
            });

            ResponseTopicTwister<TurnDTO> response = turnService.FinishTurn(turnId, finishTurnDTO.Time, words, categoriesIDs);
            return response;
        }
    }
}

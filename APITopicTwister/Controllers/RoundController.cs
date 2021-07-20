﻿using Microsoft.AspNetCore.Mvc;
using Services;
using Services.DTOs;
using Services.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace APITopicTwister.Controllers
{
    [ApiController]
    public class RoundController : Controller {
        /*[HttpGet("CreateRound")]
        public ResponseTopicTwister<RoundDTO> CreateRound(PlayerDTO player1, PlayerDTO player2, SessionDTO session) {
            RoundService roundService = new RoundService();
            ResponseTopicTwister<RoundDTO> response = roundService.CreateRound(player1.playerID, player2.playerID, session.SessionID);
            return response;
        }*/

        [HttpPost("round/{roundID}/letterAndCategories")]
        //[Consumes(MediaTypeNames.Application.Json)]
        public ResponseTopicTwister<RoundDTO> AddLetterAndCategories(string roundID, RoundLetterAndCategoriesDTO letterAndCategoriesDTO)
        {
            RoundService roundService = new RoundService();
            ResponseTopicTwister<RoundDTO> response = roundService.AddLetterAndCategories(roundID, letterAndCategoriesDTO.LetterID, letterAndCategoriesDTO.CategoriesIDs);
            return response;
        }

        [HttpGet("round/{roundID}")]
        public ResponseTopicTwister<RoundDTO> GetRoundById(string roundID)
        {
            RoundService roundService = new RoundService();
            ResponseTopicTwister<RoundDTO> response = roundService.GetRoundById(roundID);
            return response;
        }

        [HttpGet("round/{roundID}/result")]
        public ResponseTopicTwister<RoundResultDTO> GetRoundResult(string roundID)
        {
            RoundResultService roundResultService = new RoundResultService();
            ResponseTopicTwister<RoundResultDTO> response = roundResultService.GetRoundResult(roundID);
            return response;
        }

    }
}

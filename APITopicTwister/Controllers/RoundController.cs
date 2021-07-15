using Microsoft.AspNetCore.Mvc;
using Services;
using Services.DTOs;
using Services.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITopicTwister.Controllers
{
    public class RoundController : Controller {
        [HttpGet("CreateRound")]
        public ResponseTopicTwister<RoundDTO> CreateRound(PlayerDTO player1, PlayerDTO player2, SessionDTO session) {
            RoundService roundService = new RoundService();
            ResponseTopicTwister<RoundDTO> response = roundService.CreateRound(player1.playerID, player2.playerID, session.SessionID);
            return response;
        }

        [HttpPost("AddLetterAndCategories")]
        public ResponseTopicTwister<RoundDTO> AddLetterAndCategories(string roundId, string letterId, List<string> categoriesID)
        {
            RoundService roundService = new RoundService();
            ResponseTopicTwister<RoundDTO> response = roundService.AddLetterAndCategories(roundId, letterId, categoriesID);
            return response;
        }
    }
}

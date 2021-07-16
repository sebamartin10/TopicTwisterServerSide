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
    public class PlayerSessionController : Controller
    {
        [HttpPost("CreatePlayerSession")]
        public ResponseTopicTwister<PlayerSessionDTO> CreatePlayerSession(PlayerDTO playerDTO, SessionDTO sessionDTO)
        {
            PlayerSessionService playerSessionService = new PlayerSessionService();
            ResponseTopicTwister<PlayerSessionDTO> response = playerSessionService.CreatePlayerSession(playerDTO.playerID, sessionDTO.SessionID);
            return response;
        }
        [HttpGet("sessions/active/{playerID}")]
        public ResponseTopicTwister<List<ActiveSessionDTO>> GetActiveSessionsByPlayer(string playerID) {
            ResponseTopicTwister<List<ActiveSessionDTO>> response = new ResponseTopicTwister<List<ActiveSessionDTO>>();
            PlayerSessionService playerSessionService = new PlayerSessionService();
            response = playerSessionService.GetActiveSessionsByPlayer(playerID);
            return response;
        }


    }
}

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
    public class PlayerSessionController : Controller
    {
        private readonly ContextDB contexto;
        public PlayerSessionController(ContextDB contexto) {
            this.contexto = contexto;
        }

        [HttpPost("CreatePlayerSession")]
        public ResponseTopicTwister<PlayerSessionDTO> CreatePlayerSession(PlayerDTO playerDTO, SessionDTO sessionDTO)
        {
            PlayerSessionService playerSessionService = new PlayerSessionService(contexto);
            ResponseTopicTwister<PlayerSessionDTO> response = playerSessionService.CreatePlayerSession(playerDTO.playerID, sessionDTO.SessionID);
            return response;
        }
        [HttpGet("sessions/active/{playerID}")]
        public ResponseTopicTwister<List<ActiveSessionDTO>> GetActiveSessionsByPlayer(string playerID) {
            ResponseTopicTwister<List<ActiveSessionDTO>> response = new ResponseTopicTwister<List<ActiveSessionDTO>>();
            PlayerSessionService playerSessionService = new PlayerSessionService(contexto);
            response = playerSessionService.GetActiveSessionsByPlayer(playerID);
            return response;
        }
        [HttpGet("sessions/finished/{playerID}")]
        public ResponseTopicTwister<List<FinishedSessionDTO>> GetFinishedSessionsByPlayer(string playerID) {
            ResponseTopicTwister<List<FinishedSessionDTO>> response = new ResponseTopicTwister<List<FinishedSessionDTO>>();
            PlayerSessionService playerSessionService = new PlayerSessionService(contexto);
            response = playerSessionService.GetFinishedSessionsByPlayer(playerID);
            return response;
        }


    }
}

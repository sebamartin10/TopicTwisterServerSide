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
    public class SessionController : Controller {
        [HttpGet("CreateSession")]
        public ResponseTopicTwister<SessionDTO> CreateSession() {
            SessionService sessionService = new SessionService();
            ResponseTopicTwister<SessionDTO> response = sessionService.CreateSession();
            return response;
        }

        [HttpGet("CreateSessionByPlayers")]
        public ResponseTopicTwister<SessionDTO> CreateSession(string player1, string player2) {
            try {
                SessionService sessionService = new SessionService();
                SessionDTO response = sessionService.CreateSession(player1, player2);
                return new ResponseTopicTwister<SessionDTO>(response);
            } catch (Exception e){
                return new ResponseTopicTwister<SessionDTO>(null,-1,e.Message);
            }
        }

        [HttpGet("GetAllSessions")]
        public ResponseTopicTwister<List<SessionDTO>> GetAllSessions()
        {
            SessionService sessionService = new SessionService();
            ResponseTopicTwister<List<SessionDTO>> response = sessionService.GetAllSessions();
            return response;
        }

        [HttpGet("GetSessionById")]
        public ResponseTopicTwister<SessionDTO> GetSessionById(SessionDTO sessionDto)
        {
            SessionService sessionService = new SessionService();
            ResponseTopicTwister<SessionDTO> response = sessionService.GetSessionById(sessionDto.SessionID);
            return response;
        }
    }
}

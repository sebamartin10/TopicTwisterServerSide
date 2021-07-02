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

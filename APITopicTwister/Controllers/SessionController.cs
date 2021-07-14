using Microsoft.AspNetCore.Mvc;
using Services;
using Services.DTOs;
using Services.Errors;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITopicTwister.Controllers
{
    [ApiController]
    [Route("session")]
    public class SessionController : Controller {
        /*[HttpGet("CreateSession")]
        public ResponseTopicTwister<SessionDTO> CreateSession() {
            SessionService sessionService = new SessionService();
            ResponseTopicTwister<SessionDTO> response = sessionService.CreateSession();
            return response;
        }*/

        [HttpGet("{player1},{player2}")]
        [SwaggerOperation(Summary = "Start new session for 2 players")]
        public ResponseTopicTwister<SessionDTO> CreateSession(string player1, string player2) {
            try {
                SessionService sessionService = new SessionService();
                SessionDTO response = sessionService.CreateSession(player1, player2);
                return new ResponseTopicTwister<SessionDTO>(response);
            } catch (Exception e){
                return new ResponseTopicTwister<SessionDTO>(null,-1,e.Message);
            }
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all sessions")]
        public ResponseTopicTwister<List<SessionDTO>> GetAllSessions()
        {
            SessionService sessionService = new SessionService();
            ResponseTopicTwister<List<SessionDTO>> response = sessionService.GetAllSessions();
            return response;
        }

        [HttpGet("{sessionID}")]
        [SwaggerOperation(Summary = "Get a session")]
        public ResponseTopicTwister<SessionDTO> GetSessionById(string sessionID)
        {
            SessionService sessionService = new SessionService();
            ResponseTopicTwister<SessionDTO> response = sessionService.GetSessionById(sessionID);
            return response;
        }
    }
}

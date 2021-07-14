using Microsoft.AspNetCore.Mvc;
using Services;
using Services.DTOs;
using Services.Errors;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace APITopicTwister.Controllers
{
    [ApiController]
    [Route("player")]
    public class PlayerController : Controller {
        [HttpGet("CreatePlayer")]
        public ResponseTopicTwister<PlayerDTO> CreatePlayer(PlayerDTO playerDTO) {
            PlayerService playerService = new PlayerService();
            ResponseTopicTwister<PlayerDTO> response = playerService.CreatePlayer(playerDTO.playerName);
            return response;
        }

        [HttpGet("{playerID}/Opponent")]
        [SwaggerOperation(Summary = "Get a opponent for a player")]
        public ResponseTopicTwister<PlayerDTO> GetOpponent(string playerID) {
            //throw new Exception("Hola Mundo");
            try {
                PlayerService playerService = new PlayerService();
                PlayerDTO dto = playerService.GetOpponent(playerID);
                return new ResponseTopicTwister<PlayerDTO>(dto);
            } catch (Exception e) {
                return new ResponseTopicTwister<PlayerDTO>(null,-1,e.Message);
            }
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create player")]
        //[Consumes(MediaTypeNames.Application.Json)]
        public ResponseTopicTwister<PlayerDTO> RegisterPlayer(PlayerDTO playerDTO)
        {
            PlayerService playerService = new PlayerService();
            ResponseTopicTwister<PlayerDTO> response = playerService.RegisterPlayer(playerDTO.playerName,playerDTO.password, playerDTO.playerID);
            return response;
        }


    }

}

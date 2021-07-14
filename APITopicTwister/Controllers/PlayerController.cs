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
    public class PlayerController : Controller {
        [HttpGet("CreatePlayer")]
        public ResponseTopicTwister<PlayerDTO> CreatePlayer(PlayerDTO playerDTO) {
            PlayerService playerService = new PlayerService();
            ResponseTopicTwister<PlayerDTO> response = playerService.CreatePlayer(playerDTO.playerName);
            return response;
        }

        [HttpGet("GetOpponent")]
        public ResponseTopicTwister<PlayerDTO> GetOpponent(PlayerDTO playerDTO) {
            try {
                PlayerService playerService = new PlayerService();
                PlayerDTO dto = playerService.GetOpponent(playerDTO.playerID);
                return new ResponseTopicTwister<PlayerDTO>(dto);
            } catch (Exception e) {
                return new ResponseTopicTwister<PlayerDTO>(null,-1,e.Message);
            }
        }

        [HttpGet("RegisterPlayer")]
        public ResponseTopicTwister<PlayerDTO> RegisterPlayer(PlayerDTO playerDTO)
        {
            ResponseTopicTwister<PlayerDTO> response = PlayerService.RegisterPlayer(playerDTO);
            return response;
        }


    }

}

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

    }
}

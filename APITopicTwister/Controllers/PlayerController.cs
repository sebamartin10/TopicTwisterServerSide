using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITopicTwister.Controllers
{
    public class PlayerController : Controller
    {
        [HttpGet("CreatePlayer")]
        public PlayerDTO CreatePlayer(PlayerDTO playerDTO) {
            PlayerService playerService = new PlayerService();
            PlayerDTO player = playerService.CreatePlayer(playerDTO.playerName);
            return player;
        }
        
    }
}

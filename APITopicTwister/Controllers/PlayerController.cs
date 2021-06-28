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
    public class PlayerController : Controller
    {
        [HttpGet("CreatePlayer")]
        public (PlayerDTO,ResponseTopicTwister) CreatePlayer(PlayerDTO playerDTO) {
            //SqlServerContext context = new SqlServerContext();
            PlayerService playerService = new PlayerService();
            (PlayerDTO,ResponseTopicTwister) response = playerService.CreatePlayer(playerDTO.playerName);
            return response;
        }
        
    }
}

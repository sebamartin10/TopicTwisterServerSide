using Models;
using Services.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class PlayerService
    {
        public PlayerDTO CreatePlayer(string name)
        {
            Player player = new Player
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = name
            };

            PlayerDTO playerDTO = new PlayerDTO
            {
                playerID = player.PlayerID,
                playerName = player.PlayerName
            };
            return playerDTO;
        }
    }
}

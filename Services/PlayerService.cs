using Models;
using Services.DTOs;
using Services.Errors;
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

        public static ResponseTopicTwister VerifyName(string name)
        {
            ResponseTopicTwister response = new ResponseTopicTwister();
            if (name.Length<4) {
                response.ResponseCode = -1;
                response.ResponseMessage = "Nombre debe tener al menos 4 (cuatro) caracteres.";
            }
            return response;
        }
    }
}

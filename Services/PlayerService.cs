using Models;
using Repository.Contracts;
using Repository.Repos;
using Services.DTOs;
using Services.Errors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class PlayerService
    {
        public (PlayerDTO,ResponseTopicTwister) CreatePlayer(string name)
        {
            ResponseTopicTwister response = new ResponseTopicTwister();
            try
            {
                response = VerifyName(name);
                if (response.ResponseCode!=0) {
                    return (null, response);
                }
                Player player = new Player
                {
                    PlayerID = Guid.NewGuid().ToString(),
                    PlayerName = name
                };
                PlayerRepository playerRepo = new PlayerRepository();
                playerRepo.Create(player);

                PlayerDTO playerDTO = new PlayerDTO
                {
                    playerID = player.PlayerID,
                    playerName = player.PlayerName
                };
                return (playerDTO,response);
            }
            catch (Exception ex)
            {
                response.ResponseCode = -1;
                response.ResponseMessage = ex.Message;
                return (null, response);
            }
            

            
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

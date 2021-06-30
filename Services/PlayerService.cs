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
        public ResponseTopicTwister<PlayerDTO> CreatePlayer(string name)
        {
            try
            {
                ResponseTopicTwister<PlayerDTO> response = VerifyName(name);
                if (response.ResponseCode!=0) {
                    return (response);
                }

                Player player = new Player
                {
                    PlayerID = Guid.NewGuid().ToString(),
                    PlayerName = name
                };

                IPlayerRepository playerRepo = new PlayerRepository();
                playerRepo.Create(player);

                response.Dto = new PlayerDTO
                {
                    playerID = player.PlayerID,
                    playerName = player.PlayerName
                };

                return response;
            }
            catch (Exception ex)
            {
                return new ResponseTopicTwister<PlayerDTO>(null,-1,ex.Message);
            }         
            
        }

        public static ResponseTopicTwister<PlayerDTO> VerifyName(string name)
        {
            ResponseTopicTwister<PlayerDTO> response = new ResponseTopicTwister<PlayerDTO>();
            if (name.Length<4) {
                response.ResponseCode = -1;
                response.ResponseMessage = "Nombre debe tener al menos 4 (cuatro) caracteres.";
            }
            return response;
        }
    }
}

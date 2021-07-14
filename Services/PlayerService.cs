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
        private static PlayerDTO PlayerToDTO(Player player) {
            return new PlayerDTO() {
                playerID = player.PlayerID,
                playerName = player.PlayerName
            };
        }

        public PlayerDTO GetOpponent(string playerID) {
            IPlayerRepository playerRepository = new PlayerRepository();
            Player player = playerRepository.FindById(playerID);

            Player opponent =null;
            while(opponent== null || opponent == player) {
                opponent = playerRepository.FindRandomPlayer();
            }

            return PlayerToDTO(opponent) ;
        }

        public ResponseTopicTwister<PlayerDTO> CreatePlayer(string name)
        {
            try
            {
                ResponseTopicTwister<PlayerDTO> response = new ResponseTopicTwister<PlayerDTO>();
                response = VerifyName(name);
                if (response.ResponseCode!=0) {
                    return (response);
                }

                name = name.ToUpper();
                response = VerifyPlayerDuplicated(name);
                if (response.ResponseCode!=0) {
                    return response;
                }

                Player player = new Player
                {
                    PlayerID = Guid.NewGuid().ToString(),
                    PlayerName = name
                };

                IPlayerRepository playerRepo = new PlayerRepository();
                playerRepo.Create(player);

                response.Dto = PlayerToDTO(player);

                return response;
            }
            catch (Exception ex)
            {
                return new ResponseTopicTwister<PlayerDTO>(null,-1,ex.Message);
            }         
            
        }

        public ResponseTopicTwister<PlayerDTO> Login(PlayerDTO playerDTO)
        {
            ResponseTopicTwister<PlayerDTO> response = new ResponseTopicTwister<PlayerDTO>();
            PlayerRepository playerRepo = new PlayerRepository();
            Player player = playerRepo.FindByNameAndPassword(playerDTO.playerName,playerDTO.password);
            if (player==null) {
                response.ResponseCode = -1;
                response.ResponseMessage = "Credenciales incorrectas.";
                return response;
            }
            response.Dto = new PlayerDTO
            {
                playerID = player.PlayerID,
                playerName = player.PlayerName,
                password = player.Password
            };
            return response;
        }

        public static ResponseTopicTwister<PlayerDTO> VerifyName(string name)
        {
            ResponseTopicTwister<PlayerDTO> response = new ResponseTopicTwister<PlayerDTO>();
            if (string.IsNullOrEmpty(name)||name.Length<4) {
                response.ResponseCode = -1;
                response.ResponseMessage = "Nombre debe tener al menos 4 (cuatro) caracteres.";
            }
            return response;
        }
        public static ResponseTopicTwister<PlayerDTO> VerifyPlayerDuplicated(string name) {
            ResponseTopicTwister<PlayerDTO> response = new ResponseTopicTwister<PlayerDTO>();
            PlayerRepository playerRepo = new PlayerRepository();
            Player player = playerRepo.FindByName(name);
            if (player != null) {
                response.ResponseCode = -1;
                response.ResponseMessage = "El jugador ya existe";
                response.Dto = PlayerToDTO(player);
                return response;
            }
            return response;
        }
    }
}

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
            int trys = 0;
            while(opponent== null || opponent == player||trys<50) {
                opponent = playerRepository.FindRandomPlayer();
                trys++;
            }

            return PlayerToDTO(opponent) ;
        }

        public ResponseTopicTwister<PlayerDTO> Login(PlayerDTO playerDTO) {
            ResponseTopicTwister<PlayerDTO> response = new ResponseTopicTwister<PlayerDTO>();
            PlayerRepository playerRepo = new PlayerRepository();
            Player player = playerRepo.FindByNameAndPassword(playerDTO.playerName, playerDTO.password);
            if (player == null) {
                response.ResponseCode = -1;
                response.ResponseMessage = "Credenciales incorrectas.";
                return response;
            }
            response.Dto = new PlayerDTO {
                playerID = player.PlayerID,
                playerName = player.PlayerName
                //,password = player.Password
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

        public static ResponseTopicTwister<PlayerDTO> VerifyPlayerDuplicated(string name, string password) {
            ResponseTopicTwister<PlayerDTO> response = new ResponseTopicTwister<PlayerDTO>();
            PlayerRepository playerRepo = new PlayerRepository();
            Player player = playerRepo.FindByName(name);
            if (player != null) {
                response.ResponseCode = -1;
                response.ResponseMessage = "¡El jugador ya existe!";
            }
            return response;
        }

        public ResponseTopicTwister<PlayerDTO> RegisterPlayer(string name, string password, string id)
        {
            try
            {
                ResponseTopicTwister<PlayerDTO> response = new ResponseTopicTwister<PlayerDTO>();

                response = VerifyName(name);
                if (response.ResponseCode != 0)
                {
                    return (response);
                }

                response = VerifyPass(password);
                if (response.ResponseCode != 0)
                {
                    return (response);
                }

                name = name.ToUpper();
                response = VerifyPlayerDuplicated(name, password);
                if (response.ResponseCode != 0)
                {
                    return response;
                }
                id = !string.IsNullOrEmpty(id) ? id : Guid.NewGuid().ToString();
                Player player = new Player
                {
                    PlayerID = id,
                    PlayerName = name,
                    Password = password
                };

                IPlayerRepository playerRepo = new PlayerRepository();
                playerRepo.Create(player);
                Player playerValidator = new Player();
                playerValidator = playerRepo.FindById(id);
                if (playerValidator == null)
                {
                    response.ResponseCode = -1;
                    response.ResponseMessage ="No se pudo efectuar la operación de registro";
                }
                response.Dto = PlayerToDTO(player);

                return response;
            }
            catch (Exception ex)
            {
                return new ResponseTopicTwister<PlayerDTO>(null, -1, ex.Message);
            }

        }

        public static ResponseTopicTwister<PlayerDTO> VerifyPass(string password)
        {
            ResponseTopicTwister<PlayerDTO> response = new ResponseTopicTwister<PlayerDTO>();
            if (string.IsNullOrEmpty(password) || password.Length < 4 || password.Length > 10)
            {
                response.ResponseCode = -1;
                response.ResponseMessage = "Contraseña debe tener entre 4 (cuatro) y 10 (diez) caracteres.";
            }
            return response;
        }
    }
}

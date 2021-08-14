using Models;
using Models.Entities;
using Repository.Contracts;
using Repository.Repos;
using Services.Contracts;
using Services.DTOs;
using Services.Errors;
using System;
using System.Collections.Generic;
using System.Text;


namespace Services
{
    public class PlayerService : IPlayerService
    {
        private readonly ContextDB contexto;
        private IPlayerRepository playerRepository;
        public PlayerService() { }
        public PlayerService(ContextDB contexto) {
            this.contexto = contexto;
            playerRepository = new PlayerRepository(contexto);
        }
        private static PlayerDTO PlayerToDTO(Player player) {
            return new PlayerDTO() {
                playerID = player.PlayerID,
                playerName = player.PlayerName
            };
        }

        public PlayerDTO GetOpponent(string playerID) {
            Player player = playerRepository.FindById(playerID);

            var playerSesionRepository = new PlayerSessionRepository(contexto);
            var sessions = playerSesionRepository.FindAllActivePlayerSessions(playerID);
            var currentOpponents = new List<Player>();
            var potentialOpponents = playerRepository.FindAll();

            potentialOpponents.RemoveAll(player=> player.PlayerID == playerID);
            foreach (Session session in sessions) {
                var players = playerSesionRepository.FindPlayersBySession(session.SessionID);
                var opponents = players.FindAll(opponent => opponent.PlayerID != playerID);
                currentOpponents.AddRange(opponents);
                opponents.ForEach(player => potentialOpponents.Remove(player));
            }

            Player opponent = null;
            if (potentialOpponents.Count > 0) {
                opponent = potentialOpponents[new Random().Next(0, potentialOpponents.Count)];
            } else {
                int trys = 0;
                while (opponent == null || opponent == player || trys < 50) {
                    opponent = playerRepository.FindRandomPlayer();
                    trys++;
                }
            }
            return PlayerToDTO(opponent) ;
        }

        public ResponseTopicTwister<PlayerDTO> Login(PlayerDTO playerDTO) {
            ResponseTopicTwister<PlayerDTO> response = new ResponseTopicTwister<PlayerDTO>();
            Player player = playerRepository.FindByNameAndPassword(playerDTO.playerName, playerDTO.password,contexto);
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

        public ResponseTopicTwister<PlayerDTO> VerifyName(string name)
        {
            ResponseTopicTwister<PlayerDTO> response = new ResponseTopicTwister<PlayerDTO>();
            if (string.IsNullOrEmpty(name)||name.Length<4) {
                response.ResponseCode = -1;
                response.ResponseMessage = "Nombre debe tener al menos 4 (cuatro) caracteres.";
            }
            return response;
        }

        public ResponseTopicTwister<PlayerDTO> VerifyPlayerDuplicated(string name, string password) {
            ResponseTopicTwister<PlayerDTO> response = new ResponseTopicTwister<PlayerDTO>();
            Player player = playerRepository.FindByName(name);
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

                playerRepository.Create(player);
                Player playerValidator = new Player();
                playerValidator = playerRepository.FindById(id);
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

        public ResponseTopicTwister<PlayerDTO> VerifyPass(string password)
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

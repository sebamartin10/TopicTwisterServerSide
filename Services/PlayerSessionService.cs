using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Repository.Contracts;
using Repository.Repos;
using Services.DTOs;
using Services.Errors;

namespace Services
{
    public class PlayerSessionService
    {
        IPlayerSessionRepository playerSessionRepository;


        public ResponseTopicTwister<PlayerSessionDTO> CreatePlayerSession(string playerID, string sessionID)
        {
            try
            {
                ResponseTopicTwister<PlayerSessionDTO> response = new ResponseTopicTwister<PlayerSessionDTO>();

                playerSessionRepository = new PlayerSessionRepository();

                Player player = new Player();
                PlayerRepository playerRepository = new PlayerRepository();
                player = playerRepository.FindById(playerID);

                Session session = new Session();
                SessionRepository sessionRepository = new SessionRepository();
                session = sessionRepository.FindById(sessionID);

                PlayerSession playerSession = new PlayerSession()
                {
                    PlayerSessionID = Guid.NewGuid().ToString(),
                    PlayerID = player.PlayerID,
                    SessionID = session.SessionID
                };

                playerSessionRepository.Create(playerSession);

                response.Dto = new PlayerSessionDTO

                {
                    PlayerSessionID = Guid.NewGuid().ToString(),
                    PlayerID = player.PlayerID,
                    SessionID = session.SessionID
                };
                return response;
            }
            catch (Exception ex)
            {
                return new ResponseTopicTwister<PlayerSessionDTO>(null, -1, ex.Message);
            }
        }

    }
}

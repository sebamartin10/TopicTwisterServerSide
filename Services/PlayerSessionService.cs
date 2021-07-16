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

        public ResponseTopicTwister<List<ActiveSessionDTO>> GetActiveSessionsByPlayer(string playerID)
        {
            ResponseTopicTwister<List<ActiveSessionDTO>> response = new ResponseTopicTwister<List<ActiveSessionDTO>>();
            try
            {
                RoundRepository roundRepo = new RoundRepository();
                TurnRepository turnRepo = new TurnRepository();
                
                response.Dto = new List<ActiveSessionDTO>();
                PlayerSessionRepository playerSessionRepo = new PlayerSessionRepository();
                List<Session> activeSessions = playerSessionRepo.FindAllActivePlayerSessions(playerID);
                if (activeSessions.Count == 0)
                {

                    response.ResponseMessage = "No existen sesiones activas para el player";
                    return response;
                }

                foreach (var sessionActive in activeSessions)
                {
                    ActiveSessionDTO asDTO = new ActiveSessionDTO();
                    asDTO.SessionID = sessionActive.SessionID;
                    List<Round> rounds = roundRepo.FindBySession(sessionActive.SessionID);
                    asDTO.RoundsCount = rounds.Count;

                    Round actualRound = rounds.Where(x => x.Finished == false).OrderBy(x=>x.roundNumber).First();
                    asDTO.CurrentRoundNumber = actualRound.roundNumber;
                    Player oponent = turnRepo.FindOponent(playerID);
                    asDTO.OpponentName = oponent.PlayerName;
                    Turn actualTurn = actualRound.Turns.Where(x => x.finished == false && x.PlayerID == playerID).FirstOrDefault();
                    if (actualTurn == null)
                    {
                        asDTO.IsLocalPlayer = true;
                    }
                    else
                    {
                        asDTO.IsLocalPlayer = false;
                    }
                    response.Dto.Add(asDTO);
                }

                return response;
            }
            catch (Exception ex)
            {
                response.ResponseCode = -1;
                response.ResponseMessage = ex.Message;
                return response;
            }
            
        }
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

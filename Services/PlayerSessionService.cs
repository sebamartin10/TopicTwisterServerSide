using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.Entities;
using Repository.Contracts;
using Repository.Repos;
using Services.DTOs;
using Services.Enums;
using Services.Errors;

namespace Services
{
    public class PlayerSessionService
    {
        private readonly ContextDB contexto;

        public PlayerSessionService(ContextDB contexto) {
            this.contexto = contexto;
        }

        IPlayerSessionRepository playerSessionRepository;
        public ResponseTopicTwister<List<FinishedSessionDTO>> GetFinishedSessionsByPlayer(string playerID) {
            ResponseTopicTwister<List<FinishedSessionDTO>> response = new ResponseTopicTwister<List<FinishedSessionDTO>>();
            try {
                RoundRepository roundRepo = new RoundRepository(contexto);
                TurnRepository turnRepo = new TurnRepository(contexto);
                SessionService sessionService = new SessionService(contexto);

                response.Dto = new List<FinishedSessionDTO>();
                PlayerSessionRepository playerSessionRepo = new PlayerSessionRepository(contexto);
                List<Session> finishedSessions = playerSessionRepo.FindAllNoActivePlayerSessions(playerID);
                if (finishedSessions.Count == 0) {
                    response.ResponseMessage = "No se pudo recuperar un historial de sesiones para el player";
                    return response;
                }

                PlayerRepository playerRepository = new PlayerRepository(contexto);

                foreach (var sessionFinished in finishedSessions) {
                    FinishedSessionDTO finishedSessionDTO = new FinishedSessionDTO();
                    List<SessionResult> sessionsResults = sessionService.GetSessionResults(sessionFinished.SessionID);

                    finishedSessionDTO.SessionID = sessionFinished.SessionID;

                    Player playerOponent = playerSessionRepo.FindPlayersBySession(sessionFinished.SessionID).Find(x => x.PlayerID != playerID);
                    finishedSessionDTO.OpponentID = playerOponent.PlayerID;
                    finishedSessionDTO.OpponentName = playerOponent.PlayerName;

                    if (sessionsResults.Count > 0) {
                        finishedSessionDTO.playerLocalStatus = sessionsResults.Where(x => x.PlayerID == playerID).First().StatusPlayer;
                    } else {
                        finishedSessionDTO.NeedShowResult =true;
                    }

                    response.Dto.Add(finishedSessionDTO);
                }
                return response;

            } catch (Exception ex) {
                response.ResponseCode = -1;
                response.ResponseMessage = ex.Message;
                return response;
            }


        }
        public ResponseTopicTwister<List<ActiveSessionDTO>> GetActiveSessionsByPlayer(string playerID) {
            ResponseTopicTwister<List<ActiveSessionDTO>> response = new ResponseTopicTwister<List<ActiveSessionDTO>>();
            try {
                RoundRepository roundRepo = new RoundRepository(contexto);
                TurnRepository turnRepo = new TurnRepository(contexto);
                PlayerRepository playerRepo = new PlayerRepository(contexto);

                response.Dto = new List<ActiveSessionDTO>();
                PlayerSessionRepository playerSessionRepo = new PlayerSessionRepository(contexto);
                List<Session> activeSessions = playerSessionRepo.FindAllActivePlayerSessions(playerID);
                if (activeSessions.Count == 0) {

                    response.ResponseMessage = "No existen sesiones activas para el player";
                    return response;
                }

                foreach (var sessionActive in activeSessions) {
                    ActiveSessionDTO asDTO = new ActiveSessionDTO();
                    asDTO.SessionID = sessionActive.SessionID;
                    List<Round> rounds = roundRepo.FindBySession(sessionActive.SessionID);
                    asDTO.RoundsCount = rounds.Count;

                    Round actualRound = rounds.Where(x => x.Finished == false).OrderBy(x => x.roundNumber).FirstOrDefault();
                    if (actualRound != null) {
                        asDTO.CurrentRoundNumber = actualRound.roundNumber;
                        if (actualRound != null) {
                            string opponentId = actualRound.Turns.ToList().Find(x => x.PlayerID != playerID)?.PlayerID;
                            Player opponent = playerRepo.FindById(opponentId);
                            asDTO.OpponentName = opponent.PlayerName;

                            Turn actualTurn = actualRound.Turns.Where(x => x.finished == false).OrderBy(x => x.turnNumber).FirstOrDefault();
                            asDTO.IsLocalPlayer = actualTurn != null && actualTurn.PlayerID == playerID;
                        }
                    }

                    response.Dto.Add(asDTO);

                }

                return response;
            } catch (Exception ex) {
                response.ResponseCode = -1;
                response.ResponseMessage = ex.Message;
                return response;
            }

        }
        public ResponseTopicTwister<PlayerSessionDTO> CreatePlayerSession(string playerID, string sessionID) {
            try {
                ResponseTopicTwister<PlayerSessionDTO> response = new ResponseTopicTwister<PlayerSessionDTO>();

                playerSessionRepository = new PlayerSessionRepository(contexto);

                Player player = new Player();
                PlayerRepository playerRepository = new PlayerRepository(contexto);
                player = playerRepository.FindById(playerID);

                Session session = new Session();
                SessionRepository sessionRepository = new SessionRepository(contexto);
                session = sessionRepository.FindById(sessionID);

                PlayerSession playerSession = new PlayerSession() {
                    PlayerSessionID = Guid.NewGuid().ToString(),
                    PlayerID = player.PlayerID,
                    SessionID = session.SessionID
                };

                playerSessionRepository.Create(playerSession);

                response.Dto = new PlayerSessionDTO {
                    PlayerSessionID = Guid.NewGuid().ToString(),
                    PlayerID = player.PlayerID,
                    SessionID = session.SessionID
                };
                return response;
            } catch (Exception ex) {
                return new ResponseTopicTwister<PlayerSessionDTO>(null, -1, ex.Message);
            }
        }

    }
}

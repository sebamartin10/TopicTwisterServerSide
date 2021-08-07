using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.DTOs;
using Services.Errors;
using Models;
using Repository.Contracts;
using Repository.Repos;
using Models.Entities;

namespace Services
{
    public class SessionService
    {
        private SessionRepository sessionRepository;
        private RoundService roundService;

        public SessionService() {
            this.roundService = new RoundService();
        }

        public SessionDTO CreateSession(string player1ID, string player2ID) {

            sessionRepository = new SessionRepository();
            Session session = new Session {
                SessionID = Guid.NewGuid().ToString(),
                isActive = true
            };
            sessionRepository.Create(session);

            PlayerRepository playerRepository = new PlayerRepository();

            Player player1 = playerRepository.FindById(player1ID);
            Player player2 = playerRepository.FindById(player2ID);

            RoundService roundService = new RoundService();

            int amountOfRounds = 3;
            Round[] rounds = new Round[amountOfRounds];
            for (int i = 0; i < amountOfRounds; i++) {
                if (i % 2 == 0) {
                    rounds[i] = roundService.CreateRound(player1, player2, session, i + 1);
                } else {
                    rounds[i] = roundService.CreateRound(player2, player1, session, i + 1);
                }
            }

            session.Rounds = rounds;

            PlayerSessionRepository playerSessionRepository = new PlayerSessionRepository();

            PlayerSession playerSession = new PlayerSession() {
                PlayerID = player1.PlayerID,
                PlayerSessionID = Guid.NewGuid().ToString(),
                SessionID = session.SessionID
            };
            playerSessionRepository.Create(playerSession);

            PlayerSession playerSession2 = new PlayerSession() {
                PlayerID = player2.PlayerID,
                PlayerSessionID = Guid.NewGuid().ToString(),
                SessionID = session.SessionID
            };

            playerSessionRepository.Create(playerSession2);

            return ConvertToDTO(session);
        }

        public ResponseTopicTwister<SessionDTO> CreateSession() {
            try {
                ResponseTopicTwister<SessionDTO> responseSession = new ResponseTopicTwister<SessionDTO>();
                sessionRepository = new SessionRepository();
                Session session = new Session {
                    SessionID = Guid.NewGuid().ToString()
                };
                sessionRepository.Create(session);

                Session restoredSession = sessionRepository.FindById(session.SessionID);

                if (restoredSession == null) {
                    responseSession.ResponseCode = -1;
                    responseSession.ResponseMessage = "No se pudo crear la sesion";
                    return responseSession;
                }

                responseSession.Dto = this.ConvertToDTO(restoredSession);
                return responseSession;
            } catch (Exception ex) {
                return new ResponseTopicTwister<SessionDTO>(null, -1, ex.Message);
            }
        }
        public SessionDTO ConvertToDTO(Session session) {
            List<RoundDTO> roundsListDto = new List<RoundDTO>();

            if (session.Rounds != null) {
                foreach (var round in session.Rounds.OrderBy(x => x.roundNumber)) {
                    roundsListDto.Add(roundService.ConvertToDTO(round));
                }
            }

            SessionDTO sessionDto = new SessionDTO {
                SessionID = session.SessionID,
                Rounds = roundsListDto,
                CurrentRound = roundsListDto.Find(x => !x.Finished),
                Finished = !session.isActive
                
            };
            return sessionDto;
        }
        public ResponseTopicTwister<List<SessionDTO>> GetAllSessions() {
            try {
                ResponseTopicTwister<List<SessionDTO>> responseSessions = new ResponseTopicTwister<List<SessionDTO>>();
                sessionRepository = new SessionRepository();
                List<Session> sessions = new List<Session>();
                sessions = sessionRepository.FindAllSessions();
                List<SessionDTO> sessionsDto = new List<SessionDTO>();
                foreach (Session session in sessions) {
                    sessionsDto.Add(this.ConvertToDTO(session));
                }
                responseSessions.Dto = sessionsDto;
                return responseSessions;
            } catch (Exception ex) {
                return new ResponseTopicTwister<List<SessionDTO>>(null, -1, ex.Message);
            }
        }
        public ResponseTopicTwister<SessionDTO> GetSessionById(string sessionId) {
            try {
                ResponseTopicTwister<SessionDTO> responseSession = new ResponseTopicTwister<SessionDTO>();
                sessionRepository = new SessionRepository();
                Session session = new Session();
                session = sessionRepository.FindById(sessionId);
                if (session == null) {
                    responseSession.ResponseCode = -1;
                    responseSession.ResponseMessage = "No se pudo encontrar la sesion";
                    return responseSession;
                }

                var roundRepository = new RoundRepository();
                var rounds = roundRepository.FindBySession(sessionId);


                var roundCategoryRepository = new RoundCategoryRepository();
                var categoryRepository = new CategoryRepository();
                var letterRepository = new LetterRepository();

                rounds.ForEach(round => {
                    List<RoundCategory> roundCategories = roundCategoryRepository.FindAllByRound(round.RoundID);
                    round.Categories = roundCategories;
                    round.Letter = letterRepository.FindById(round.LetterID);
                });

                session.Rounds = rounds;

                responseSession.Dto = this.ConvertToDTO(session);
                return responseSession;
            } catch (Exception ex) {
                return new ResponseTopicTwister<SessionDTO>(null, -1, ex.Message);
            }
        }

        public List<SessionResult> GetSessionResults(string sessionID) {
            SessionRepository sessionRepo = new SessionRepository();
            List<SessionResult> sessionsResult = sessionRepo.GetSessionResults(sessionID);
            return sessionsResult;
        }

    }
}

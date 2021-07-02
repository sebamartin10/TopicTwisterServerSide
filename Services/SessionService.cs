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

namespace Services
{
    public class SessionService
    {
        private SessionRepository sessionRepository;
        private RoundService roundService;

        public SessionService()
        {
            this.roundService = new RoundService();
        }

        public ResponseTopicTwister<SessionDTO> CreateSession()
        {
            try
            {
                ResponseTopicTwister<SessionDTO> responseSession = new ResponseTopicTwister<SessionDTO>();
                sessionRepository = new SessionRepository();
                Session session = new Session
                {
                    SessionID = Guid.NewGuid().ToString()
                };
                sessionRepository.Create(session);

                Session restoredSession = sessionRepository.FindById(session.SessionID);

                if(restoredSession == null)
                {
                    responseSession.ResponseCode = -1;
                    responseSession.ResponseMessage = "No se pudo crear la sesion";
                    return responseSession;
                }

                responseSession.Dto = this.ConvertToDTO(restoredSession);
                return responseSession;
            }
            catch (Exception ex)
            {
                return new ResponseTopicTwister<SessionDTO>(null, -1, ex.Message);
            }
        }
        public SessionDTO ConvertToDTO(Session session)
        {
            List<RoundDTO> roundsListDto = new List<RoundDTO>();
            if (session.Rounds != null)
            {
                foreach (var round in session.Rounds)
                {
                    roundsListDto.Add(roundService.ConvertToDTO(round));
                }
            }
            SessionDTO sessionDto = new SessionDTO
            {
                SessionID = session.SessionID,
                Rounds = roundsListDto
            };
            return sessionDto;
        }
        public ResponseTopicTwister<List<SessionDTO>> GetAllSessions()
        {
            try
            {
                ResponseTopicTwister<List<SessionDTO>> responseSessions = new ResponseTopicTwister<List<SessionDTO>>();
                sessionRepository = new SessionRepository();
                List<Session> sessions = new List<Session>();
                sessions = sessionRepository.FindAllSessions();
                List<SessionDTO> sessionsDto = new List<SessionDTO>();
                foreach(Session session in sessions)
                {
                    sessionsDto.Add(this.ConvertToDTO(session));
                }
                responseSessions.Dto = sessionsDto;
                return responseSessions;
            }
            catch (Exception ex)
            {
                return new ResponseTopicTwister<List<SessionDTO>>(null, -1, ex.Message);
            }
        }
        public ResponseTopicTwister<SessionDTO> GetSessionById(string sessionId)
        {
            try
            {
                ResponseTopicTwister<SessionDTO> responseSession = new ResponseTopicTwister<SessionDTO>();
                sessionRepository = new SessionRepository();
                Session session = new Session();
                session = sessionRepository.FindById(sessionId);
                if (session == null)
                {
                    responseSession.ResponseCode = -1;
                    responseSession.ResponseMessage = "No se pudo encontrar la sesion";
                    return responseSession;
                }
                responseSession.Dto = this.ConvertToDTO(session);
                return responseSession;
            }
            catch (Exception ex)
            {
                return new ResponseTopicTwister<SessionDTO>(null, -1, ex.Message);
            }
        }
    }
}

using Models;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace Repository.Repos
{
    public class PlayerSessionRepository : IPlayerSessionRepository
    {
        private readonly ContextDB contexto;
        public PlayerSessionRepository(ContextDB contexto)
        {
            this.contexto = contexto;
        }

        public void Create(PlayerSession playerSession)
        {
            contexto.PlayerSessions.Add(playerSession);
            contexto.SaveChanges();
        }

        public void Delete(PlayerSession playerSession)
        {
            contexto.PlayerSessions.Remove(playerSession);
            contexto.SaveChanges();
        }

        public List<PlayerSession> FindAllPlayerSession()
        {
            return contexto.PlayerSessions.ToList();
        }
        public List<Session> FindAllActivePlayerSessions(string playerID) {
            List<Session> activeSessions = (from x in contexto.PlayerSessions
                                            .Include(y => y.Session)
                                            where x.PlayerID == playerID && x.Session.isActive == true
                                            select x.Session).ToList();
            return activeSessions;
        }
        public List<Session> FindAllNoActivePlayerSessions(string playerID) {
            List<Session> noActiveSessions = (from x in contexto.PlayerSessions
                                              .Include(y => y.Session)
                                              where x.PlayerID == playerID && x.Session.isActive == false
                                              select x.Session).ToList();
            return noActiveSessions;
        }
        public PlayerSession FindByPlayerAndSession(string PlayerID, string SessionID)
        {
            PlayerSession playerSession = (from x in contexto.PlayerSessions
                                           where x.PlayerID == PlayerID && x.SessionID == SessionID
                                           select x).First();
            return playerSession;
        }

        public PlayerSession FindByPlayerSessionID(string PlayerSessionID)
        {
            PlayerSession playerSession = (from x in contexto.PlayerSessions
                                           where x.PlayerSessionID == PlayerSessionID
                                           select x).First();
            return playerSession;
        }

        public List<Player> FindPlayersBySession(string SessionID)
        {
            List<Player> players = (from x in contexto.PlayerSessions
                                           where x.SessionID == SessionID
                                           select x.Player).ToList();
            return players;
        }
    }
}

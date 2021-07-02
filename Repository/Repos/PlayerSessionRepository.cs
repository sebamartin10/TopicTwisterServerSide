using Models;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Repository.Repos
{
    public class PlayerSessionRepository : IPlayerSessionRepository
    {
        private readonly SQLServerContext context;
        public PlayerSessionRepository()
        {
            context = new SQLServerContext();
        }

        public void Create(PlayerSession playerSession)
        {
            context.PlayerSessions.Add(playerSession);
            context.SaveChanges();
        }

        public void Delete(PlayerSession playerSession)
        {
            context.PlayerSessions.Remove(playerSession);
            context.SaveChanges();
        }

        public List<PlayerSession> FindAllPlayerSession()
        {
            return context.PlayerSessions.ToList();
        }

        public PlayerSession FindByPlayerAndSession(string PlayerID, string SessionID)
        {
            PlayerSession playerSession = (from x in context.PlayerSessions
                                           where x.PlayerID == PlayerID && x.SessionID == SessionID
                                           select x).First();
            return playerSession;
        }

        public PlayerSession FindByPlayerSessionID(string PlayerSessionID)
        {
            PlayerSession playerSession = (from x in context.PlayerSessions
                                           where x.PlayerSessionID == PlayerSessionID
                                           select x).First();
            return playerSession;
        }
    }
}

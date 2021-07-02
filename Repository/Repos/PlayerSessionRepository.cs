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
            throw new NotImplementedException();
        }

        public List<PlayerSession> FindAllPlayerSession()
        {
            throw new NotImplementedException();
        }

        public PlayerSession FindByPlayerAndSession(string PlayerID, string SessionID)
        {
            throw new NotImplementedException();
        }

        public PlayerSession FindByPlayerSessionID(string PlayerSessionID)
        {
            throw new NotImplementedException();
        }
    }
}

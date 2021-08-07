using Models;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Contracts
{
    public interface IPlayerSessionRepository
    {
        public void Create(PlayerSession playerSession);
        public void Delete(PlayerSession playerSession);
        public PlayerSession FindByPlayerSessionID(string PlayerSessionID);
        public PlayerSession FindByPlayerAndSession(string PlayerID, string SessionID);
        public List<PlayerSession> FindAllPlayerSession();
    }
}

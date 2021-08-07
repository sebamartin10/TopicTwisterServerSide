using Models;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Contracts
{
    public interface ISessionResultRepository
    {
        public void Create(SessionResult sessionResult);
        public List<SessionResult> FindBySession(string sessionID);
    }
}

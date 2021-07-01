using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Contracts
{
    public interface ISessionRepository
    {
        public void Create(Session session);
        public void Delete(Session session);
        public void Update(Session session);
        public Session FindById(string id);
        public List<Session> FindAllSessions();
    }
}

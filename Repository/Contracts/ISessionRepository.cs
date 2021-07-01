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
<<<<<<< HEAD
        public Session FindById(string id);
=======
        public Session GetById(string id);
>>>>>>> f3fb79ae11e9873747f02695f0a64cc5e3267509
        public List<Session> FindAllSessions();
    }
}

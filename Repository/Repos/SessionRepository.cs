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
    public class SessionRepository : ISessionRepository
    {
        private readonly ContextDB contexto;

        

        public SessionRepository(ContextDB contexto)
        {
            this.contexto = contexto;
        }
        public void Create(Session session)
        {
            contexto.Sessions.Add(session);
            contexto.SaveChanges();

        }

        public void Update(Session session)
        {
            contexto.Sessions.Update(session);
            contexto.SaveChanges();
        }

        public void Delete(Session session)
        {
            contexto.Sessions.Remove(session);
            contexto.SaveChanges();
        }

        public List<Session> FindAllSessions()
        {
            return contexto.Sessions.Include(x => x.Rounds).ToList();
        }

        public Session FindById(string id)
        {
            Session session = (from x in contexto.Sessions
                               .Include(x => x.Rounds)
                           where x.SessionID == id
                           select x).FirstOrDefault();
            return session;
        }
        public List<SessionResult> GetSessionResults(string sessionID) {
            Session session = (from x in contexto.Sessions
                                                  .Include(y => y.SessionResults)
                                                  where x.SessionID == sessionID
                                                  select x).First();
            return session.SessionResults.ToList();
        }
        
    }
}

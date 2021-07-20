using Models;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repos
{
    public class SessionRepository : ISessionRepository
    {
        private readonly SQLServerContext context;

        

        public SessionRepository()
        {
            context = new SQLServerContext();
        }
        public void Create(Session session)
        {
            context.Sessions.Add(session);
            context.SaveChanges();

        }

        public void Update(Session session)
        {
            context.Sessions.Update(session);
            context.SaveChanges();
        }

        public void Delete(Session session)
        {
            context.Sessions.Remove(session);
            context.SaveChanges();
        }

        public List<Session> FindAllSessions()
        {
            return context.Sessions.Include(x => x.Rounds).ToList();
        }

        public Session FindById(string id)
        {
            Session session = (from x in context.Sessions
                               .Include(x => x.Rounds)
                           where x.SessionID == id
                           select x).FirstOrDefault();
            return session;
        }
        public List<SessionResult> GetSessionResults(string sessionID) {
            Session session = (from x in context.Sessions
                                                  .Include(y => y.SessionResults)
                                                  where x.SessionID == sessionID
                                                  select x).First();
            return session.SessionResults.ToList();
        }
        
    }
}

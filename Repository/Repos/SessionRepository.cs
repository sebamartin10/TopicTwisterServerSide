using Models;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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
            return context.Sessions.ToList();
        }

        public Session FindById(string id)
        {
            Session session = (from x in context.Sessions
                           where x.SessionID == id
                           select x).First();
            return session;
        }
    }
}

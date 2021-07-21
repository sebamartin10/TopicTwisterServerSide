using Models;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repos
{
    public class SessionResultRepository : ISessionResultRepository
    {
        private readonly SQLServerContext context;

        public SessionResultRepository()
        {
            context = new SQLServerContext();
        }
        public void Create(SessionResult sessionResult)
        {
            context.SessionResults.Add(sessionResult);
            context.SaveChanges();
        }

        public List<SessionResult> FindBySession(string sessionID)
        {
            List<SessionResult> sessionResult = (from x in context.SessionResults
                                              where x.SessionID == sessionID
                                              select x).ToList();
            return sessionResult;
        }
    }
}

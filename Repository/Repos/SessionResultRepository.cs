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
    public class SessionResultRepository : ISessionResultRepository
    {
        private readonly ContextDB contexto;

        public SessionResultRepository(ContextDB contexto)
        {
            this.contexto = contexto;
        }
        public void Create(SessionResult sessionResult)
        {
            contexto.SessionResults.Add(sessionResult);
            contexto.SaveChanges();
        }

        public List<SessionResult> FindBySession(string sessionID)
        {
            List<SessionResult> sessionResult = (from x in contexto.SessionResults
                                              where x.SessionID == sessionID
                                              select x).ToList();
            return sessionResult;
        }
    }
}

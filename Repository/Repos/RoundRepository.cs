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
    public class RoundRepository : IRoundRepository
    {
        private readonly ContextDB contexto;

        

        public RoundRepository(ContextDB contexto)
        {
            this.contexto = contexto;
        }
        public void Create(Round round)
        {
            contexto.Rounds.Add(round);
            contexto.SaveChanges();

        }

        public void Update(Round round)
        {
            contexto.Rounds.Update(round);
            contexto.SaveChanges();
        }

        public void Delete(Round round)
        {
            contexto.Rounds.Remove(round);
            contexto.SaveChanges();
        }

        public Round FindById(string id)
        {
            Round round = (from x in contexto.Rounds
                           .Include(x => x.Turns).Include(x =>x.Letter)
                           where x.RoundID == id
                           select x).FirstOrDefault();
            return round;
        }

        public List<Round> FindBySession(string sessionID)
        {
            List<Round> rounds = (from x in contexto.Rounds
                                  .Include(y => y.Turns).OrderBy(x => x.roundNumber)
                                  where x.SessionID == sessionID
                                  select x).ToList();
            return rounds;

        }


    }
}

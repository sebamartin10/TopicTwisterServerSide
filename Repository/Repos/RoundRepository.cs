using Models;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repos
{
    public class RoundRepository : IRoundRepository
    {
        private readonly SQLServerContext context;

        

        public RoundRepository()
        {
            context = new SQLServerContext();
        }
        public void Create(Round round)
        {
            context.Rounds.Add(round);
            context.SaveChanges();

        }

        public void Update(Round round)
        {
            context.Rounds.Update(round);
            context.SaveChanges();
        }

        public void Delete(Round round)
        {
            context.Rounds.Remove(round);
            context.SaveChanges();
        }

        public Round FindById(string id)
        {
            Round round = (from x in context.Rounds
                           .Include(x => x.Turns).Include(x =>x.Letter)
                           where x.RoundID == id
                           select x).FirstOrDefault();
            return round;
        }

        public List<Round> FindBySession(string sessionID)
        {
            List<Round> rounds = (from x in context.Rounds
                                  .Include(y => y.Turns).OrderBy(x => x.roundNumber)
                                  where x.SessionID == sessionID
                                  select x).ToList();
            return rounds;

        }


    }
}

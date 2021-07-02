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
            throw new NotImplementedException();
        }

        public Round FindById(string id)
        {
            Round round = (from x in context.Rounds
                           .Include(x => x.Turns)
                           where x.RoundID == id
                           select x).First();
            return round;
        }
    }
}

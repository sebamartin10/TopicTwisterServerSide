using Models;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repos
{
    public class RoundResultRepository : IRoundResultRepository
    {
        private readonly SQLServerContext context;

        

        public RoundResultRepository()
        {
            context = new SQLServerContext();
        }
        public void Create(RoundResult roundResult)
        {
            context.RoundResults.Add(roundResult);
            context.SaveChanges();
        }

        public List<RoundResult> FindByRound(string roundID)
        {
            List<RoundResult> roundResults = (from x in context.RoundResults
                                  .Include(y => y.Player)
                                  where x.RoundID == roundID
                                  select x).ToList();
            return roundResults;
        }
    }
}

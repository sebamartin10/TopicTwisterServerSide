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
    public class RoundResultRepository : IRoundResultRepository
    {
        private readonly ContextDB contexto;

        

        public RoundResultRepository(ContextDB contexto)
        {
            this.contexto = contexto;
        }
        public void Create(RoundResult roundResult)
        {
            contexto.RoundResults.Add(roundResult);
            contexto.SaveChanges();
        }

        public List<RoundResult> FindByRound(string roundID)
        {
            List<RoundResult> roundResults = (from x in contexto.RoundResults
                                  .Include(y => y.Player)
                                  where x.RoundID == roundID
                                  select x).ToList();
            return roundResults;
        }
    }
}

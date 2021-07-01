using Models;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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
            // Esto tiene sentido? O primero debo hacer un find con el id?
            context.Rounds.Update(round);
            //context.SaveChanges();
        }

        public void Delete(Round round)
        {
            throw new NotImplementedException();
        }

        public Round GetById(string id)
        {
            Round round = context.Rounds.Single<Round>(c => c.RoundID == id);
            return round;
        }
    }
}

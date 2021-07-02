using Models;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Repository.Repos
{
    public class TurnRepository : ITurnRepository
    {
        private readonly SQLServerContext context;
        public TurnRepository()
        {
            context = new SQLServerContext();
        }
        public void Create(Turn turn)
        {
            context.Turns.Add(turn);
            context.SaveChanges();

        }

        public void Update(Turn turn)
        {
            context.Turns.Update(turn);
            context.SaveChanges();
        }

        public void Delete(Turn turn)
        {
            throw new NotImplementedException();
        }
        public Turn FindByTurn(string id)
        {
            Turn turn = (from x in context.Turns
                           where x.TurnID == id
                           select x).First();
            return turn;
        }
    }
}

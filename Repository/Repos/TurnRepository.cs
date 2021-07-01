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
            // Esto tiene sentido? O primero debo hacer un find con el id?
            context.Turns.Update(turn);
            //context.SaveChanges();
        }

        public void Delete(Turn turn)
        {
            throw new NotImplementedException();
        }

<<<<<<< HEAD
        public Turn FindById(string id)
=======
        public Turn FindByTurn(string id)
>>>>>>> f3fb79ae11e9873747f02695f0a64cc5e3267509
        {
            Turn turn = context.Turns.Single<Turn>(c => c.TurnID == id);
            return turn;
        }
    }
}

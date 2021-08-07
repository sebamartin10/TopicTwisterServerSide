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
    public class TurnRepository : ITurnRepository
    {
        private readonly ContextDB contexto;
        public TurnRepository(ContextDB contexto)
        {
            this.contexto = contexto;
        }
        public void Create(Turn turn)
        {
            contexto.Turns.Add(turn);
            contexto.SaveChanges();

        }

        public void Update(Turn turn)
        {
            contexto.Turns.Update(turn);
            contexto.SaveChanges();
        }

        public void Delete(Turn turn)
        {
            contexto.Turns.Remove(turn);
        }
        public Turn FindByTurn(string id)
        {
            Turn turn = (from x in contexto.Turns
                         where x.TurnID == id
                           select x).FirstOrDefault();
            return turn;
        }
        public Player FindOponent(string NoOponentplayerID) {
            Player player = (from x in contexto.Turns
                             .Include(y=>y.Player)
                             where x.PlayerID != NoOponentplayerID
                             select x.Player).First();
            return player;
        }

        public List<Turn> FindByRound(string roundId)
        {
            List<Turn> turns = (from x in contexto.Turns
                                .Include(y=>y.Answers)
                                where x.RoundID == roundId
                                select x).ToList();
            return turns;
        }
    }
}

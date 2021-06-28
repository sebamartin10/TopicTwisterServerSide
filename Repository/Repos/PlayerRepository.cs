using Models;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Repository.Repos
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly SQLServerContext context;
        public PlayerRepository() {
            context = new SQLServerContext();
        }
        public void Create(Player player)
        {
            context.Players.Add(player);
            context.SaveChanges();

        }

        public void Delete(Player player)
        {
            throw new NotImplementedException();
        }

        public List<Player> FindAll()
        {
            throw new NotImplementedException();
        }

        public Player FindByUser(string user)
        {

            return null;
        }

        public void Update(Player player)
        {
            throw new NotImplementedException();
        }
    }
}

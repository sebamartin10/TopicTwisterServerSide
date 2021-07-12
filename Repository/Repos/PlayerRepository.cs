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
            context.Players.Remove(player);
            context.SaveChanges();
        }

        public List<Player> FindAll()
        {
            return context.Players.ToList();
        }

        public Player FindById(string id)
        {
            Player player = (from x in context.Players
                           where x.PlayerID == id
                           select x).First();
            return player;
        }
        public Player FindByName(string name)
        {
            Player player = (from x in context.Players
                             where x.PlayerName == name
                             select x).FirstOrDefault();
            return player;
        }

        public Player FindRandomPlayer() {
            Player[] players = context.Players.ToArray();

            if (players.Length==0) 
                return null;

            return players[new Random().Next(0,players.Length)];
        }

        public void Update(Player player)
        {
            context.Players.Update(player);
            context.SaveChanges();
        }
    }
}

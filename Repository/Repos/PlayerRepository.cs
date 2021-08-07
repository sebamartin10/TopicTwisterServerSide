using Models;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Models.Entities;

namespace Repository.Repos
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly ContextDB contexto;
        public PlayerRepository(ContextDB contexto) {
            this.contexto = contexto;
        }
        public void Create(Player player)
        {
            contexto.Players.Add(player);
            contexto.SaveChanges();

        }

        public void Delete(Player player)
        {
            contexto.Players.Remove(player);
            contexto.SaveChanges();
        }

        public List<Player> FindAll()
        {
            return contexto.Players.ToList();
        }

        public Player FindById(string id)
        {
            Player player = (from x in contexto.Players
                           where x.PlayerID == id
                           select x).First();
            return player;
        }
        public Player FindByName(string name)
        {
            Player player = (from x in contexto.Players
                             where x.PlayerName == name
                             select x).FirstOrDefault();
            return player;
        }
        public Player FindByNameAndPassword(string name,string password, ContextDB contexto)
        {
            Player player = (from x in contexto.Players
                             where x.PlayerName == name && x.Password==password
                             select x).FirstOrDefault();
            return player;
        }

        public Player FindRandomPlayer() {
            Player[] players = contexto.Players.ToArray();

            if (players.Length==0) 
                return null;

            return players[new Random().Next(0,players.Length)];
        }

        public void Update(Player player)
        {
            contexto.Players.Update(player);
            contexto.SaveChanges();
        }
    }
}

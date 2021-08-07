using Models;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Contracts
{
    public interface IPlayerRepository
    {
        public void Create(Player player);
        public void Update(Player player);
        public void Delete(Player player);
        public Player FindById(string id);
        public List<Player> FindAll();
        public Player FindRandomPlayer();
    }
}

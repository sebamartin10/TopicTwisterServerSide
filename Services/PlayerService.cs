using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class PlayerService
    {
        public Player CreatePlayer(string name)
        {
            Player player = new Player
            {
                PlayerID = Guid.NewGuid().ToString(),
                PlayerName = name
            };
            return player;
        }
    }
}

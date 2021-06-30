using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Player
    {
        public string PlayerID { get; set; }
        public string PlayerName { get; set; }
        public virtual ICollection<PlayerSession> PlayerSessions { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Entities
{
    public class Player
    {
        public string PlayerID { get; set; }
        public string PlayerName { get; set; }
        public string Password { get; set; }
        public virtual ICollection<PlayerSession> PlayerSessions { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Entities
{
    public class SessionResult
    {
        public string SessionResultID { get; set; }
        public int StatusPlayer { get; set; }
        public string SessionID { get; set; }
        public Player Player { get; set; }
        public string PlayerID { get; set; }
    }
}

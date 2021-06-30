using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class PlayerSession
    {
        public string PlayerSessionID { get; set; }
        public string PlayerID { get; set; }
        public string SessionID { get; set; }
        public virtual Session Session { get; set; }

}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    class PlayerSession
    {
        public string PlayerSessionID { get; set; }
        public virtual Player Player { get; set; }
        public virtual Session Session { get; set; }

}
}

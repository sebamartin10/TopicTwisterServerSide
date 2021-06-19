using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    class Session
    {
        public string SessionID { get; set; }
        public virtual ICollection<Round> Rounds { get; set; }
    }
}

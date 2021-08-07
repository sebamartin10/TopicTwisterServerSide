using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Entities
{
    public class Session
    {
        public string SessionID { get; set; }
        public virtual ICollection<Round> Rounds { get; set; }
        public bool isActive { get; set; }
        public virtual ICollection<SessionResult> SessionResults { get; set; }
    }
}

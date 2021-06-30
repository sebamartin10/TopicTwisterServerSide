using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Turn
    {
        public string TurnID { get; set; }
        public string PlayerID { get; set; }
        public virtual Player Player { get; set; }
        public string RoundID { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
    }
}

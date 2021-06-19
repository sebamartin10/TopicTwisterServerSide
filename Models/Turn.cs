using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    class Turn
    {
        public string TurnID { get; set; }
        public virtual Player Player { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
    }
}

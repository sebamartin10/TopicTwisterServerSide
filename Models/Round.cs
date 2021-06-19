
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    class Round
    {
        public string RoundID { get; set; }
        public virtual ICollection<Turn> Turns { get; set; }
        public virtual Letter Letter { get; set; }
    }
}

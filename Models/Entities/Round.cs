﻿
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Entities
{
    public class Round
    {
        public string RoundID { get; set; }
        public virtual ICollection<Turn> Turns { get; set; }
        public string SessionID { get; set; }
        public string LetterID { get; set; }
        public virtual Letter Letter { get; set; }
        public bool Finished { get; set; }
        public int roundNumber { get; set; }
        public virtual ICollection<RoundCategory> Categories { get; set; }

        public virtual ICollection<RoundResult> RoundResults { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class RoundResult
    {
        public string RoundResultID { get; set; }
        public int StatusPlayer { get; set; }
        public string RoundID { get; set; }
        public Player Player { get; set; }
        public string PlayerID { get; set; }
        public int CorrectWords  { get; set; }

    }
}

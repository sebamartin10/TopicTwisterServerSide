using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs
{
    public class SessionResultDTO
    {
        public string SessionID { get; set; }
        public string Player1Name { get; set; }
        public string Player2Name { get; set; }
        public int Player1Result { get; set; }
        public int Player2Result { get; set; }
        public bool isPlayer1Winner { get; set; }
        public bool isPlayer2Winner { get; set; }
    }
}

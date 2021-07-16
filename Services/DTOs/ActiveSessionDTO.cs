using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs
{
    public class ActiveSessionDTO
    {
        public string SessionID { get; set; }
        public int CurrentRoundNumber { get; set; }
        public int RoundsCount { get; set; }
        public string OpponentName { get; set; }
        public bool IsLocalPlayer { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs
{
    public class SessionDTO
    {
        public string SessionID { get; set; }
        public List<RoundDTO> Rounds { get; set; }

        public RoundDTO CurrentRound { get; set; }
        public bool Finished { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs
{
    public class FinishedSessionDTO
    {
        public string OpponentID { get; set; }
        public string OpponentName { get; set; }
        public int playerLocalStatus { get; set; }
        public bool NeedShowResult { get; set; }
    }
}

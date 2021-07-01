using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs
{
    public class TurnDTO
    {
        public string TurnID { get; set; }
        public string PlayerID { get; set; }
        public string RoundID { get; set; }
        public virtual ICollection<string> Answers { get; set; }
    }
}

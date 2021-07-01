using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs
{
    public class RoundDTO
    {
        public string RoundID { get; set; }
        public string SessionID { get; set; }
        public string LetterID { get; set; }
        public virtual ICollection<TurnDTO> Turns { get; set; }
    }
}

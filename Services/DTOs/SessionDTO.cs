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
        public virtual List<RoundDTO> Rounds { get; set; }
    }
}

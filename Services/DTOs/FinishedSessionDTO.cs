using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs
{
    public class FinishedSessionDTO
    {
        public string OponentID { get; set; }
        public string OponentName { get; set; }
        public int playerLocalStatus { get; set; }
    }
}

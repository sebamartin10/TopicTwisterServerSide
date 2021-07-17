using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs
{
    public class RoundResultDTO
    {
        public string Player1Name { get; set; }
        public string Player2Name { get; set; }
        public virtual List<RoundResultByCategoryDTO> RoundResults { get; set; }
        public char Letter { get; set; }
        public bool isPlayer1Winner { get; set; }
        public bool isPlayer2Winner { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs
{
    public class RoundResultByCategoryDTO
    {
        public string Category { get; set; }
        public string WordPlayer1 { get; set; }
        public string WordPlayer2 { get; set; }
        public bool IsCorrectPlayer1 { get; set; }
        public bool IsCorrectPlayer2 { get; set; }
    }
}

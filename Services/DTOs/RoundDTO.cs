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
        //public string SessionID { get; set; }
        public LetterDTO letter { get; set; }
        public List<TurnDTO> Turns { get; set; }
        public bool Finished { get; set; }
        public List<PlayerDTO> Winners { get; set; }
        public PlayerDTO CurrentPlayer { get; set; }
        public TurnDTO CurrentTurn { get; set; }
        public List<CategoryDTO> categories { get; set; }
    }
}

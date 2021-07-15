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
        public virtual List<AnswerDTO> Answers { get; set; }
        public bool Finished { get; set; }
        public float FinishTime { get; set; }
        public int CorrentAnswers { get; set; }
    }
}

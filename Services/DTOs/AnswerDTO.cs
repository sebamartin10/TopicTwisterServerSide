using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs
{
    public class AnswerDTO
    {
        public string AnswerID { get; set; }
        public string WordAnswered { get; set; }
        public string WordID { get; set; }
        public string LetterID { get; set; }
        public string CategoryID { get; set; }
        public string TurnID { get; set; }
        public bool Correct { get; set; }
    }
}

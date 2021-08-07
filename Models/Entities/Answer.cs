using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Entities
{
    public class Answer
    {
        public string AnswerID { get; set; }
        public string WordAnswered { get; set; }
        public string WordID { get; set; }
        public virtual Word Word { get; set; }
        public string CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public string TurnID { get; set; }
        public bool Correct { get; set; }

    }
}

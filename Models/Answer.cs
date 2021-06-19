using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    class Answer
    {
        public string AnswerID { get; set; }
        public string WordAnswered { get; set; }
        public virtual Word Word { get; set; }
        public virtual Category Category { get; set; }
        public bool Correct { get; set; }

    }
}

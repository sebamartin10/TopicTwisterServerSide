using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APITopicTwister.Models
{
    public class Answer
    {
        [Key]
        public string AnswerID { get; set; }
        public string WordAnswered { get; set; }
        public virtual Word Word { get; set; }
        public virtual Category Category { get; set; }
    }
}

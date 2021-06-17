using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APITopicTwister.Models
{
    public class Turn
    {
        [Key]
        public string TurnID { get; set; }
        public virtual Player Player { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
    }
}
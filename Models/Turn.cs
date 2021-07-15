﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Turn
    {
        public string TurnID { get; set; }
        public string PlayerID { get; set; }
        public virtual Player Player { get; set; }
        public string RoundID { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public string LetterID { get; set; }
        public string CategoriesID { get; set; }
        public float finishTime { get; set; }
        public bool finished { get; set; }
        public int correctAnswers { get; set; }
    }
}

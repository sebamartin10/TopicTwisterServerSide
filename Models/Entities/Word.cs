using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Entities
{
    public class Word
    {
        public string WordID { get; set; }
        public string WordName { get; set; }
        public string LetterID { get; set; }
        public virtual Letter Letter { get; set; }
    }
}

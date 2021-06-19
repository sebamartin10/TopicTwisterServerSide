using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    class Word
    {
        public string WordID { get; set; }
        public virtual Letter Letter { get; set; }
    }
}

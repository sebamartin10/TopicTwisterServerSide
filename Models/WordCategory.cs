using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    class WordCategory
    {
        public string WordCategoryID { get; set; }
        public virtual Category Category { get; set; }
        public virtual Word Word { get; set; }
    }
}

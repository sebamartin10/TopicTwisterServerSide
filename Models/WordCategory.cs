using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class WordCategory
    {
        public string WordCategoryID { get; set; }
        public string CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public string WordID { get; set; }
        public virtual Word Word { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class RoundCategory
    {
        public string RoundCategoryID { get; set; }
        public virtual Category Category { get; set; }
        public virtual Round Round { get; set; }
    }
}

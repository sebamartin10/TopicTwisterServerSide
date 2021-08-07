using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Entities
{
    public class RoundCategory
    {
        public string RoundCategoryID { get; set; }
        public string CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public string RoundID { get; set; }
        public virtual Round Round { get; set; }
    }
}

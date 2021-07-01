using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs
{
    public class WordCategoryDTO
    {
        public string WordCategoryID { get; set; }
        public string CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public string WordID { get; set; }
        public virtual Word Word { get; set; }

    }
}

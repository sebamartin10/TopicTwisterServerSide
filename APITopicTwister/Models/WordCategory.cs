using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APITopicTwister.Models
{
    public class WordCategory
    {
        [Key]
        public string WordCategoryID { get; set; }
        public virtual Category Category { get; set; }
        public virtual Word Word { get; set; }
    }
}

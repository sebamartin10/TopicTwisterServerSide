using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APITopicTwister.Models
{
    public class RoundCategory
    {
        [Key]
        public string RoundCategoryID { get; set; }
        public virtual Round Round { get; set; }
        public virtual Category Category { get; set; }
    }
}

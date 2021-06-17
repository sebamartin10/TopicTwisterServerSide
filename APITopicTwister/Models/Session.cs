using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APITopicTwister.Models
{
    public class Session
    {
        [Key]
        public string SessionID { get; set; }
        public virtual ICollection<Round> Round { get; set; }
    }
}

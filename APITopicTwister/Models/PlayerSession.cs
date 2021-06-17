using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APITopicTwister.Models
{
    public class PlayerSession
    {
        [Key]
        public string PlayerSessionID { get; set; }
        public virtual Player Player { get; set; }
        public virtual Session Session { get; set; }
    }
}

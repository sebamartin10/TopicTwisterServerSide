using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APITopicTwister.Models
{
    public class Player
    {
        [Key]
        public string PlayerID { get; set; }
        public string PlayerName { get; set; }
    }
}

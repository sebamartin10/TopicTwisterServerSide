using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs
{
    public class WordDTO
    {
        public string WordID { get; set; }
        public string WordName { get; set; }
        public virtual Letter Letter { get; set; }

    }
}

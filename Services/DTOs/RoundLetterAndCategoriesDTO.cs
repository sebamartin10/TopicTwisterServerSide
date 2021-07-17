using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs
{
    public class RoundLetterAndCategoriesDTO
    {
        public string RoundID { get; set; }
        public string LetterID { get; set; }
        public List<string> CategoriesIDs { get; set; }
    }
}

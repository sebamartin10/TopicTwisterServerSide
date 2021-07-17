using System;
using System.Collections.Generic;

namespace Services.DTOs
{
    public class FinishTurnDTO
    {
        public float Time { get; set; }
        public List<FinishTurnWordCategoryDTO> WordCategories { get; set; }
    }
}

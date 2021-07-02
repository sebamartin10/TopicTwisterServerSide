using Microsoft.AspNetCore.Mvc;
using Repository.Repos;
using Services;
using Services.DTOs;
using Services.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITopicTwister.Controllers
{
    public class RoundCategoryController : Controller
    {
        [HttpPost("CreateRoundCategory")]
        public ResponseTopicTwister<RoundCategoryDTO> CreateRoundCategory(RoundDTO roundDTO, CategoryDTO categoryDTO)
        {
            RoundCategoryService roundCategoryService = new RoundCategoryService();
            ResponseTopicTwister<RoundCategoryDTO> response = roundCategoryService.CreateRoundCategory(roundDTO.RoundID, categoryDTO.CategoryID);
            return response;
        }


    }
}

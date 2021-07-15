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
    public class TurnController : Controller
    {
        [HttpPost("AddLetterAndCategories")]
        public ResponseTopicTwister<TurnDTO> AddLetterAndCategories(string turnId, string letterId, List<string> categories)
        {
            TurnService turnService = new TurnService();
            ResponseTopicTwister<TurnDTO> response = turnService.AddLetterAndCategories(turnId, letterId, categories);
            return response;
        }


    }
}

﻿using Microsoft.AspNetCore.Mvc;
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
        [HttpPost("FinishTurn")]
        public ResponseTopicTwister<TurnDTO> FinishTurn(string turnId, float time, List<string> wordsAnswered)
        {
            TurnService turnService = new TurnService();
            ResponseTopicTwister<TurnDTO> response = turnService.FinishTurn(turnId, time, wordsAnswered);
            return response;
        }


    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.DTOs;
using Services.Errors;
using Models;
using Repository.Contracts;
using Repository.Repos;
using Models.Entities;

namespace Services
{
    public class RoundService
    {
        private readonly ContextDB contexto;
        private RoundRepository roundRepository;
        private TurnService turnService;
        private CategoryService categoryService;

        public RoundService(ContextDB contexto) {
            this.contexto = contexto;
            this.turnService = new TurnService(contexto);
            this.categoryService = new CategoryService(contexto);
        }

        private Player CheckPlayer(string playerId) {
            PlayerRepository playerRepository = new PlayerRepository(contexto);
            Player player = new Player();
            player = playerRepository.FindById(playerId);
            return player;
        }
        private Session CheckSession(string sessionId) {
            SessionRepository sessionRepository = new SessionRepository(contexto);
            Session session = new Session();
            session = sessionRepository.FindById(sessionId);
            return session;
        }

        private Letter CheckLetter(string letterId) {
            LetterRepository letterRepository = new LetterRepository(contexto);
            Letter letter = new Letter();
            letter = letterRepository.FindById(letterId);
            return letter;
        }
        private Category CheckCategory(string categoryId)
        {
            Category category = new Category();
            category = categoryService.GetCategory(categoryId);
            return category;
        }

        public ResponseTopicTwister<RoundDTO> GetRoundById(string roundID)
        {
            try
            {
                ResponseTopicTwister<RoundDTO> responseRound = new ResponseTopicTwister<RoundDTO>();
                roundRepository = new RoundRepository(contexto);
                Round round = roundRepository.FindById(roundID);
                responseRound.Dto = this.ConvertToDTO(round);
                return responseRound;
            }
            catch (Exception ex)
            {
                return new ResponseTopicTwister<RoundDTO>(null, -1, ex.Message);
            }
        }

        internal Round CreateRound(Player player1, Player player2, Session session, int roundNumber) {
            roundRepository = new RoundRepository(contexto);
            Round round = new Round {
                RoundID = Guid.NewGuid().ToString(),
                SessionID = session.SessionID,
                roundNumber = roundNumber
            };
            roundRepository.Create(round);

            Turn turn1 = turnService.CreateTurn(player1, round.RoundID, 1);
            Turn turn2 = turnService.CreateTurn(player2, round.RoundID, 2);

            round.Turns = new List<Turn>() { turn1, turn2 };

            return round;
        }

        public ResponseTopicTwister<RoundDTO> CreateRound(string player1Id, string player2Id, string sessionId) {
            try {
                ResponseTopicTwister<RoundDTO> responseRound = new ResponseTopicTwister<RoundDTO>();
                PlayerRepository playerRepository = new PlayerRepository(contexto);
                Player player1 = CheckPlayer(player1Id);
                Player player2 = CheckPlayer(player2Id);
                Session session = CheckSession(sessionId);
                if (player1 == null) {
                    responseRound.ResponseCode = -1;
                    responseRound.ResponseMessage = "El jugaror 1 no existe";
                    return responseRound;
                }
                if (player2 == null) {
                    responseRound.ResponseCode = -1;
                    responseRound.ResponseMessage = "El jugaror 2 no existe";
                    return responseRound;
                }
                if (session == null) {
                    responseRound.ResponseCode = -1;
                    responseRound.ResponseMessage = "La sesion no existe";
                    return responseRound;
                }
                roundRepository = new RoundRepository(contexto);
                Round round = new Round {
                    RoundID = Guid.NewGuid().ToString(),
                    SessionID = sessionId
                };
                roundRepository.Create(round);

                Round restoredRound = roundRepository.FindById(round.RoundID);

                if (restoredRound == null) {
                    responseRound.ResponseCode = -1;
                    responseRound.ResponseMessage = "No se pudo crear la ronda";
                    return responseRound;
                }

                Turn turn1 = turnService.CreateTurn(player1, restoredRound.RoundID, 1);
                Turn turn2 = turnService.CreateTurn(player2, restoredRound.RoundID, 2);
                if (turn1 == null || turn2 == null) {
                    responseRound.ResponseCode = -1;
                    responseRound.ResponseMessage = "Los turnos no pudieron ser creados";
                    return responseRound;
                }

                responseRound.Dto = this.ConvertToDTO(restoredRound);
                return responseRound;
            } catch (Exception ex) {
                return new ResponseTopicTwister<RoundDTO>(null, -1, ex.Message);
            }
        }


        public RoundDTO ConvertToDTO(Round round) {
            List<TurnDTO> turnsListDto = new List<TurnDTO>();
            if (round.Turns != null) {
                foreach (var turn in round.Turns.OrderBy(x => x.turnNumber)) {
                    turnsListDto.Add(turnService.ConvertToDTO(turn));
                }
            }
            LetterDTO letterDTO = null;
            if (round.Letter != null) {
                letterDTO = new LetterDTO() {
                    LetterID = round.Letter.LetterID,
                    LetterName = round.Letter.LetterName
                };
            }
            List<CategoryDTO> categoryDTOs = null;
            var categoryRepository = new CategoryRepository(contexto);

            if (round.Categories != null) {
                categoryDTOs = new List<CategoryDTO>();
                round.Categories.ToList().ForEach(categoryRound => {
                    var category = categoryRepository.FindByCategoryID(categoryRound.CategoryID);
                    categoryDTOs.Add(new CategoryDTO() { 
                        CategoryID = category.CategoryID,
                        CategoryName = category.CategoryName
                    });
                });
            }

            RoundDTO roundDto = new RoundDTO {
                RoundID = round.RoundID,
                //SessionID = round.SessionID,
                letter = letterDTO,
                LetterID = round.LetterID,
                Turns = turnsListDto,
                Winners = null,//todo GetWinners()
                CurrentPlayer = null,//ToDo GetCurrentPlayer
                CurrentTurn = turnsListDto.Find(x=>!x.Finished), //ToDo GetCurrentTurn
                categories = categoryDTOs, 
                Finished = round.Finished

            };
            return roundDto;
        }
        public ResponseTopicTwister<RoundDTO> AddLetterAndCategories(string roundId, string letterId, List<string> categories)
        {
            try
            {
                ResponseTopicTwister<RoundDTO> responseTurn = new ResponseTopicTwister<RoundDTO>();
                RoundRepository roundRepository = new RoundRepository(contexto);
                RoundCategoryService roundCategoryService = new RoundCategoryService(contexto);
                Round round = new Round();
                round = roundRepository.FindById(roundId);
                if (round == null)
                {
                    responseTurn.ResponseCode = -1;
                    responseTurn.ResponseMessage = "La ronda no existe";
                    return responseTurn;
                }
                foreach (string categoryId in categories)
                {
                    Category category = CheckCategory(categoryId);
                    if (category == null)
                    {
                        responseTurn.ResponseCode = -1;
                        responseTurn.ResponseMessage = $"La categoria {categoryId} no existe";
                        return responseTurn;
                    }
                    else
                    {
                        roundCategoryService.CreateRoundCategory(roundId, categoryId);
                    }
                }
                Letter letter = CheckLetter(letterId);
                if (letter == null)
                {
                    responseTurn.ResponseCode = -1;
                    responseTurn.ResponseMessage = "La letra no existe";
                    return responseTurn;
                }
                round.LetterID = letter.LetterID;
                //round.Letter = letter;
                roundRepository.Update(round);
                responseTurn.Dto = this.ConvertToDTO(round);
                return responseTurn;
            }
            catch (Exception ex)
            {
                return new ResponseTopicTwister<RoundDTO>(null, -1, ex.Message);
            }
        }
        public ResponseTopicTwister<RoundDTO> AddLetter(string roundId, string letterId) {
            try {
                ResponseTopicTwister<RoundDTO> responseRound = new ResponseTopicTwister<RoundDTO>();
                roundRepository = new RoundRepository(contexto);
                Round round = new Round();
                round = roundRepository.FindById(roundId);
                if (round == null) {
                    responseRound.ResponseCode = -1;
                    responseRound.ResponseMessage = "La ronda no existe";
                    return responseRound;
                }
                Letter letter = CheckLetter(letterId);
                if (letter == null) {
                    responseRound.ResponseCode = -1;
                    responseRound.ResponseMessage = "La letra no existe";
                    return responseRound;
                }
                round.LetterID = letter.LetterID;
                roundRepository.Update(round);
                responseRound.Dto = this.ConvertToDTO(round);
                return responseRound;
            } catch (Exception ex) {
                return new ResponseTopicTwister<RoundDTO>(null, -1, ex.Message);
            }
        }
    }
}

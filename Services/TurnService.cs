using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.DTOs;
using Services.Errors;
using Models;
using Repository.Contracts;
using Repository.Repos;

namespace Services
{
    public class TurnService
    {
        private TurnRepository turnRepository;
        private AnswerService answerService;
        private CategoryService categoryService;

        public TurnService() {
            this.answerService = new AnswerService();
            this.categoryService = new CategoryService(new CategoryRepository());
        }

        public Turn CreateTurn(Player player, string roundId) {
            turnRepository = new TurnRepository();
            Turn turn = new Turn {
                TurnID = Guid.NewGuid().ToString(),
                PlayerID = player.PlayerID,
                RoundID = roundId,
                //Player = player,
                Answers = new List<Answer>(),
                finished = false
            };

            turnRepository.Create(turn);

            turn.Player = player;

            return turn;
        }

        public TurnDTO ConvertToDTO(Turn turn) {
            List<AnswerDTO> answersListDto = new List<AnswerDTO>();
            if (turn.Answers != null) {
                foreach (var answer in turn.Answers) {
                    answersListDto.Add(answerService.ConvertToDTO(answer));
                }
            }
            List<CategoryDTO> categoriesListDto = new List<CategoryDTO>();
            if (turn.Categories != null)
            {
                foreach (var category in turn.Categories)
                {
                    categoriesListDto.Add(categoryService.ConvertToDTO(category));
                }
            }
            LetterDTO letterDTO = new LetterDTO();
            if (turn.Letter != null)
            {
                letterDTO.LetterID = turn.Letter.LetterID;
                letterDTO.LetterName = turn.Letter.LetterName;
            }
            TurnDTO turnDto = new TurnDTO {
                TurnID = turn.TurnID,
                PlayerID = turn.PlayerID,
                Answers = answersListDto,
                Finished = turn.finished,
                FinishTime = turn.finishTime,
                CorrentAnswers = turn.correctAnswers,
                Categories = categoriesListDto,
                Letter = letterDTO
            };
            return turnDto;
        }
        private Letter CheckLetter(string letterId)
        {
            LetterRepository letterRepository = new LetterRepository();
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
        public ResponseTopicTwister<TurnDTO> AddLetterAndCategories(string turnId, string letterId, List<string> categories)
        {
            try
            {
                ResponseTopicTwister<TurnDTO> responseTurn = new ResponseTopicTwister<TurnDTO>();
                turnRepository = new TurnRepository();
                Turn turn = new Turn();
                turn = turnRepository.FindByTurn(turnId);
                if (turn == null)
                {
                    responseTurn.ResponseCode = -1;
                    responseTurn.ResponseMessage = "El turno no existe";
                    return responseTurn;
                }
                List<Category> categoryList = new List<Category>();
                foreach(string categoryId in categories)
                {
                    Category category = CheckCategory(categoryId);
                    if (category == null)
                    {
                        responseTurn.ResponseCode = -1;
                        responseTurn.ResponseMessage = $"La categoria {categoryId} no existe";
                        return responseTurn;
                    } else
                    {
                        categoryList.Add(category);
                    }
                }
                Letter letter = CheckLetter(letterId);
                if (letter == null)
                {
                    responseTurn.ResponseCode = -1;
                    responseTurn.ResponseMessage = "La letra no existe";
                    return responseTurn;
                }
                turn.Letter = letter;
                turnRepository.Update(turn);
                responseTurn.Dto = this.ConvertToDTO(turn);
                return responseTurn;
            }
            catch (Exception ex)
            {
                return new ResponseTopicTwister<TurnDTO>(null, -1, ex.Message);
            }
        }

        public ResponseTopicTwister<TurnDTO> FinishTurn(string turnId, float time, List<string> wordsAnswered, Round round)
        {
            try
            {
                ResponseTopicTwister<TurnDTO> responseTurn = new ResponseTopicTwister<TurnDTO>();
                turnRepository = new TurnRepository();
                Turn turn = new Turn();
                turn = turnRepository.FindByTurn(turnId);
                if (turn == null)
                {
                    responseTurn.ResponseCode = -1;
                    responseTurn.ResponseMessage = "El turno no existe";
                    return responseTurn;
                }
                if (turn.Letter == null)
                {
                    responseTurn.ResponseCode = -1;
                    responseTurn.ResponseMessage = "El turno no contiene letra";
                    return responseTurn;
                }
                if (turn.Categories == null)
                {
                    responseTurn.ResponseCode = -1;
                    responseTurn.ResponseMessage = "El turno no contiene categorias";
                    return responseTurn;
                }
                if (wordsAnswered.Count != turn.Categories.Count)
                {
                    responseTurn.ResponseCode = -1;
                    responseTurn.ResponseMessage = $"La cantidad de respuestas recibidas es diferente de las esperadas: {turn.Categories.Count}";
                    return responseTurn;
                }
                int countCorrect = 0;
                for (int i = 0; i < wordsAnswered.Count; i++)
                {
                    Answer answer = answerService.CreateAnswerService(
                        wordsAnswered[i],
                        turn.Categories.ElementAt<Category>(i).CategoryName,
                        turn.Letter.LetterName,
                        turnId
                    );
                    turn.Answers.Add(answer);
                    if (answer.Correct) countCorrect++;
                }
                turn.correctAnswers = countCorrect;
                turn.finishTime = time;
                turn.finished = true;
                return responseTurn;
            }
            catch (Exception ex)
            {
                return new ResponseTopicTwister<TurnDTO>(null, -1, ex.Message);
            }
        }
    }
}

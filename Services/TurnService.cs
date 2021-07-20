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
        private RoundRepository roundRepository;
        private RoundCategoryRepository roundCategoryRepository;

        public TurnService() {
            this.answerService = new AnswerService();
            this.categoryService = new CategoryService(new CategoryRepository());
            this.roundCategoryRepository = new RoundCategoryRepository();
            this.roundRepository = new RoundRepository();
        }
        public Player GetOponent(string playerID) {
            TurnRepository turnRepo = new TurnRepository();
            Player oponent = turnRepo.FindOponent(playerID);
            return oponent;
        }
        public Turn CreateTurn(Player player, string roundId, int turnNumber) {
            turnRepository = new TurnRepository();
            Turn turn = new Turn {
                TurnID = Guid.NewGuid().ToString(),
                PlayerID = player.PlayerID,
                RoundID = roundId,
                //Player = player,
                Answers = new List<Answer>(),
                finished = false,
                turnNumber = turnNumber

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
            TurnDTO turnDto = new TurnDTO {
                TurnID = turn.TurnID,
                PlayerID = turn.PlayerID,
                Answers = answersListDto,
                Finished = turn.finished,
                FinishTime = turn.finishTime,
                CorrentAnswers = turn.correctAnswers
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

        public ResponseTopicTwister<TurnDTO> FinishTurn(string turnId, float time, List<string> wordsAnswered, List<string> categoriesIDs)
        {
            try
            {
                ResponseTopicTwister<TurnDTO> responseTurn = new ResponseTopicTwister<TurnDTO>();
                turnRepository = new TurnRepository();
                Turn turn = turnRepository.FindByTurn(turnId);
                if (turn == null)
                {
                    responseTurn.ResponseCode = -1;
                    responseTurn.ResponseMessage = "El turno no existe";
                    return responseTurn;
                }
                Round round = roundRepository.FindById(turn.RoundID);
                List<RoundCategory> roundCategories = roundCategoryRepository.FindAllByRound(turn.RoundID);
                if (round == null)
                {
                    responseTurn.ResponseCode = -1;
                    responseTurn.ResponseMessage = "La ronda no existe";
                    return responseTurn;
                }
                if (round.LetterID == null)
                {
                    responseTurn.ResponseCode = -1;
                    responseTurn.ResponseMessage = "El turno no contiene letra";
                    return responseTurn;
                }
                if (roundCategories == null)
                {
                    responseTurn.ResponseCode = -1;
                    responseTurn.ResponseMessage = "El turno no contiene categorias";
                    return responseTurn;
                }
                
                if (wordsAnswered.Count != roundCategories.Count)
                {
                    responseTurn.ResponseCode = -1;
                    responseTurn.ResponseMessage = $"La cantidad de respuestas recibidas es diferente de las esperadas: {roundCategories.Count}";
                    return responseTurn;
                }
                int countCorrect = 0;
                Letter letter = round.Letter;
                var answers = new List<Answer>(wordsAnswered.Count);
                for (int i = 0; i < wordsAnswered.Count; i++)
                {
                    Category category = CheckCategory(categoriesIDs[i]);
                    Answer answer = answerService.CreateAnswerService(
                        wordsAnswered[i],
                        categoriesIDs[i],
                        letter.LetterID,
                        turnId
                    );
                    answers.Add(answer);
                    if (answer.Correct) 
                        countCorrect++;
                }
                turn.correctAnswers = countCorrect;
                turn.finishTime = time;
                turn.finished = true;

                round.Finished = round.Turns.All(x => x.finished);

                turnRepository.Update(turn);
                roundRepository.Update(round);

                turn.Answers = answers;

                responseTurn.Dto = ConvertToDTO(turn);
                return responseTurn;
            }
            catch (Exception ex)
            {
                return new ResponseTopicTwister<TurnDTO>(null, -1, ex.Message);
            }
        }
    }
}

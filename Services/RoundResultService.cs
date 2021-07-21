using Models;
using Repository.Contracts;
using Repository.Repos;
using Services.DTOs;
using Services.Enums;
using Services.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class RoundResultService
    {
        RoundRepository roundRepository;
        TurnRepository turnRepository;
        PlayerRepository playerRepository;
        RoundCategoryRepository roundCategoryRepository;
        CategoryRepository categoryRepository;
        LetterRepository letterRepository;
        
        bool player1Win = false;
        bool player2Win = false;
        public ResponseTopicTwister<RoundResultDTO> GetRoundResult(string idRound)
        {
            try
            {
                ResponseTopicTwister<RoundResultDTO> responseRoundResult = new ResponseTopicTwister<RoundResultDTO>();
                roundRepository = new RoundRepository();
                Round round = roundRepository.FindById(idRound);

                turnRepository = new TurnRepository();
                List<Turn> turns = turnRepository.FindByRound(idRound);

                playerRepository = new PlayerRepository();
                Player player1 = playerRepository.FindById(turns[0].PlayerID);
                Player player2 = playerRepository.FindById(turns[1].PlayerID);

                roundCategoryRepository = new RoundCategoryRepository();
                List<RoundCategory> roundCategories = roundCategoryRepository.FindAllByRound(idRound);

                categoryRepository = new CategoryRepository();
                List<Category> categories = new List<Category>();
                // Se lo agregamos mas abajo con cada answer porq se desordenan las cosas si no
                //foreach (RoundCategory roundCategory in roundCategories)
                //{
                //    categories.Add(categoryRepository.FindByCategoryID(roundCategory.CategoryID));
                //}

                letterRepository = new LetterRepository();
                Letter letter = letterRepository.FindById(round.LetterID);

                List<Answer> player1answers = new List<Answer>();
                foreach(Answer answer in turns[0].Answers)
                {
                    Category category = categoryRepository.FindByCategoryID(answer.CategoryID);
                    categories.Add(category);
                    player1answers.Add(answer);
                }

                List<Answer> player2answers = new List<Answer>();
                foreach (Answer answer in turns[1].Answers)
                {
                    player2answers.Add(answer);
                }

                if(turns[0].correctAnswers > turns[1].correctAnswers)
                {
                    player1Win = true;
                } else if(turns[0].correctAnswers < turns[1].correctAnswers)
                {
                    player2Win = true;
                } else if(turns[0].finishTime < turns[1].finishTime)
                {
                    player1Win = true;
                } else if (turns[0].finishTime > turns[1].finishTime)
                {
                    player2Win = true;
                } else
                {
                    player1Win = true;
                    player2Win = true;
                }
                // Comprobar si los dos han terminado, si no todavia no hay ganador
                if (!turns[0].finished || !turns[1].finished)
                {
                    player1Win = false;
                    player2Win = false;
                }

                List<RoundResultByCategoryDTO> roundResultByCategoryDTOs = new List<RoundResultByCategoryDTO>();
                for (int i = 0; i < categories.Count; i++)
                {
                    string Category = categories[i].CategoryName;
                    string WordPlayer1 = i < turns[0].Answers.Count ? turns[0].Answers.ElementAt(i).WordAnswered : "";
                    bool isCorrectPlayer1 = i < turns[0].Answers.Count ? turns[0].Answers.ElementAt(i).Correct : false;
                    string WordPlayer2 = i < turns[1].Answers.Count ? turns[1].Answers.ElementAt(i).WordAnswered : "";
                    bool isCorrectPlayer2 = i < turns[1].Answers.Count ? turns[1].Answers.ElementAt(i).Correct : false;
                    roundResultByCategoryDTOs.Add(new RoundResultByCategoryDTO
                        {
                            Category = Category,
                            WordPlayer1 = WordPlayer1,
                            IsCorrectPlayer1 = isCorrectPlayer1,
                            
                            WordPlayer2 = WordPlayer2,
                            IsCorrectPlayer2 = isCorrectPlayer2
                    }
                    );
                }

                RoundResultDTO roundResultDTO = new RoundResultDTO
                {
                    Player1Name = player1.PlayerName,
                    Player2Name = player2.PlayerName,
                    RoundResults = roundResultByCategoryDTOs,
                    Letter = letter.LetterName,
                    isPlayer1Winner = player1Win,
                    isPlayer2Winner = player2Win
                };

                responseRoundResult.Dto = roundResultDTO;

                RoundResult roundResultPlayer1 = new RoundResult()
                {
                    RoundResultID = Guid.NewGuid().ToString(),
                    StatusPlayer = player1Win ? (int)PlayerEnum.Win : (int)PlayerEnum.Lost,
                    RoundID = idRound,
                    PlayerID = player1.PlayerID,
                    CorrectWords = turns[0].correctAnswers
                };

                RoundResult roundResultPlayer2 = new RoundResult()
                {
                    RoundResultID = Guid.NewGuid().ToString(),
                    StatusPlayer = player2Win ? (int)PlayerEnum.Win : (int)PlayerEnum.Lost,
                    RoundID = idRound,
                    PlayerID = player2.PlayerID,
                    CorrectWords = turns[1].correctAnswers
                };

                RoundResultRepository roundResultRepository = new RoundResultRepository();
                roundResultRepository.Create(roundResultPlayer1);
                roundResultRepository.Create(roundResultPlayer2);

                return responseRoundResult;
            }
            catch (Exception ex)
            {
                return new ResponseTopicTwister<RoundResultDTO>(null, -1, ex.Message);
            }
        }
    }
}

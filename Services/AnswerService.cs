using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Repository.Contracts;
using Repository.Repos;
using Services.DTOs;
using Services.Errors;

namespace Services
{
    public class AnswerService
    {
        IAnswerRepository answerRepository;
        private bool isCorrect;

        public ResponseTopicTwister<AnswerDTO> CreateAnswer(string wordAnswered, string categoryName, char letterName, string turnID)
        {
            try
            {
                ResponseTopicTwister<AnswerDTO> response = new ResponseTopicTwister<AnswerDTO>();
                
                answerRepository = new AnswerRepository();
                
                Category category = new Category();
                CategoryRepository categoryRepository = new CategoryRepository();
                category = categoryRepository.FindByCategory(categoryName);

                Letter letter = new Letter();
                LetterRepository letterRepository = new LetterRepository();
                letter = letterRepository.FindByLetter(letterName);

                char startLetter = wordAnswered[0];

                Turn turn = new Turn();
                TurnRepository turnRepository = new TurnRepository();
                turn = turnRepository.FindByTurn(turnID);

                Word word = new Word();
                WordRepository wordRepository = new WordRepository();

                WordCategory wordCategory = new WordCategory();
                WordCategoryRepository wordCategoryRepository = new WordCategoryRepository();

                if (wordRepository.FindByWord(wordAnswered) != null &&
                    startLetter == letter.LetterName)
                {
                    if (wordCategoryRepository.FindByWordAndCategory(wordRepository.FindByWord(wordAnswered).ToString(),
                        category.CategoryID) != null)
                    {
                        word = wordRepository.FindByWord(wordAnswered);
                        isCorrect = true;
                    }
                }
                else
                {
                    isCorrect = false;
                }

                Answer answer = new Answer() 
                {
                    AnswerID = Guid.NewGuid().ToString(),
                    WordAnswered = wordAnswered,
                    WordID = word.WordID,
                    CategoryID = category.CategoryID,
                    TurnID = turn.TurnID,
                    Correct = isCorrect
                };

                answerRepository.Create(answer);

                response.Dto = new AnswerDTO
                
                {
                    AnswerID = Guid.NewGuid().ToString(),
                    WordAnswered = wordAnswered,
                    WordID = word.WordID,
                    CategoryID = category.CategoryID,
                    TurnID = turn.TurnID,
                    Correct = isCorrect
                };
                return response;
            }
            catch (Exception ex)
            {
                return new ResponseTopicTwister<AnswerDTO>(null, -1, ex.Message);
            }
        }

        public AnswerDTO ConvertToDTO(Answer answer)
        {
            AnswerDTO answerDto = new AnswerDTO
            {
                AnswerID = answer.AnswerID,
                WordAnswered = answer.WordAnswered,
                WordID = answer.WordID,
                CategoryID = answer.CategoryID,
                TurnID = answer.TurnID,
                Correct = answer.Correct

            };
            return answerDto;
        }

        //public ResponseTopicTwister<AnswerDTO> GetResultAnswer()
        //{
        //    try
        //    {
        //        ResponseTopicTwister<AnswerDTO> response = new ResponseTopicTwister<AnswerDTO>();
        //        answerRepository = new AnswerRepository();
        //        AnswerDTO answerDTO = new AnswerDTO();
        //        Random rdm = new Random();
        //        response.Dto.Correct = answerDTO.Correct;
        //        return response;
        //    }
        //    catch (Exception ex)
        //    {
        //        return new ResponseTopicTwister<AnswerDTO>(new AnswerDTO(), -1, ex.Message);
        //    }

        //}

    }
}

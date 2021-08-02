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

                
                WordService wordService = new WordService();
                response = wordService.VerifyWord(wordAnswered);
                if (response.ResponseCode!=0) {
                    return response;
                }
                wordAnswered = wordService.ConvertToUppercase(wordAnswered);
                wordAnswered = wordService.ConvertWordBlankSpaces(wordAnswered);

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

        public Answer CreateAnswerService(string wordAnswered, string categoryId, string letterId, string turnID)
        {
            try
            {
                WordService wordService = new WordService();

                //Por ahora debe aceptar null ya que necesitamos la respuesta vacia
                if (wordAnswered == null || wordAnswered == "") wordAnswered = "-";

                bool isWordOk = wordService.VerifyWordService(wordAnswered);
                bool isCorrect = false;
                if (!isWordOk)
                {
                    throw new ArgumentException("La palabra esta vacia o contiene digitos");
                }
                
                string wordUpper = wordAnswered.ToUpper();
                char startLetterUpper = wordUpper[0];
                string wordLower = wordAnswered.ToLower();
                char startLetterLower = wordLower[0];
                wordAnswered = wordService.VerifyAccents(wordAnswered);
                wordAnswered = wordService.ConvertToUppercase(wordAnswered);
                wordAnswered = wordService.ConvertWordBlankSpaces(wordAnswered);
                
                
                answerRepository = new AnswerRepository();

                Category category = new Category();
                CategoryRepository categoryRepository = new CategoryRepository();
                category = categoryRepository.FindByCategoryID(categoryId);

                Letter letter = new Letter();
                LetterRepository letterRepository = new LetterRepository();
                letter = letterRepository.FindById(letterId);

                Turn turn = new Turn();
                TurnRepository turnRepository = new TurnRepository();
                turn = turnRepository.FindByTurn(turnID);

                WordRepository wordRepository = new WordRepository();

                WordCategory wordCategory = new WordCategory();
                WordCategoryRepository wordCategoryRepository = new WordCategoryRepository();

                Word word = wordRepository.FindByWord(wordAnswered);

                if (word != null &&
                    (startLetterUpper == letter.LetterName || startLetterLower == letter.LetterName))
                {
                    if (wordCategoryRepository.FindByWordAndCategory(word.WordID,
                        category.CategoryID) != null)
                    {
                        isCorrect = true;
                    }
                }

                Answer answer = new Answer()
                {
                    AnswerID = Guid.NewGuid().ToString(),
                    WordAnswered = wordAnswered,
                    WordID = word != null ? word.WordID : null,
                    CategoryID = category.CategoryID,
                    TurnID = turn.TurnID,
                    Correct = isCorrect
                };

                answerRepository.Create(answer);
                return answer;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

    }
}

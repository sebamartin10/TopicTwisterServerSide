using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.Entities;
using Repository.Contracts;
using Repository.Repos;
using Services.DTOs;
using Services.Errors;

namespace Services
{
    public class WordCategoryService
    {
        private readonly ContextDB contexto;
        IWordCategoryRepository wordCategoryRepository;

        public WordCategoryService(ContextDB contexto) {
            this.contexto = contexto;
        }
        public ResponseTopicTwister<WordCategoryDTO> CreateWordCategory(string categoryName, string wordName)
        {
            try
            {
                ResponseTopicTwister<WordCategoryDTO> response = new ResponseTopicTwister<WordCategoryDTO>();
                
                wordCategoryRepository = new WordCategoryRepository(contexto);                
               
                CategoryRepository categoryRepository = new CategoryRepository(contexto);
                Category category = categoryRepository.FindByCategory(categoryName);

                WordRepository wordRepository = new WordRepository(contexto);
                Word word = wordRepository.FindByWord(wordName);

                if (word == null) {
                    var wordService = new WordService(contexto);
                    var wordResponse = wordService.CreateWord(wordName);
                    if (wordResponse.ResponseCode != 0) {
                        return new ResponseTopicTwister<WordCategoryDTO>(null, wordResponse.ResponseCode, wordResponse.ResponseMessage);
                    }
                    word = wordRepository.FindByWord(wordName);
                }

                WordCategory wordCategory = new WordCategory
                {
                    WordCategoryID = Guid.NewGuid().ToString(),
                    CategoryID = category.CategoryID,
                    WordID = word.WordID
                };

                wordCategoryRepository.Create(wordCategory);

                response.Dto = new WordCategoryDTO
                
                {
                    WordCategoryID = Guid.NewGuid().ToString(),
                    CategoryID = category.CategoryID,
                    WordID = word.WordID
                };
                return response;
            }
            catch (Exception ex)
            {
                return new ResponseTopicTwister<WordCategoryDTO>(null, -1, ex.Message);
            }
        }

     }
}

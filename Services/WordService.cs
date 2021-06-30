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
    public class WordService
    {
        private List<Word> wordList = new List<Word>();
        public List<Word> WordList => wordList;

        IWordRepository wordRepository;

        //public WordService(IWordRepository wordRepository) {
        //    this.wordRepository = wordRepository;
        //    wordList = wordRepository.FindAllWord();
        //}

        public ResponseTopicTwister<WordDTO> CreateWord(string name)
        {
            try
            {
                ResponseTopicTwister<WordDTO> response = new ResponseTopicTwister<WordDTO>();
                char startLetter = name[0];
                LetterRepository letterRepository = new LetterRepository();
                Letter letter = new Letter();
                letter = letterRepository.FindByLetter(startLetter);
                wordRepository = new WordRepository();

                Word word = new Word
                {
                    WordID = Guid.NewGuid().ToString(),
                    WordName = name,
                    Letter = letter
                };

                wordRepository.Create(word);

                response.Dto = new WordDTO

                {
                    WordID = word.WordID,
                    WordName = word.WordName,
                    Letter = word.Letter 
                };
                return response;
            }
            catch (Exception ex)
            {
                return new ResponseTopicTwister<WordDTO>(null, -1, ex.Message);
            }
        }

     }
}

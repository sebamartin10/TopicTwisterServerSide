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

        public ResponseTopicTwister<WordDTO> CreateWord(string name)
        {
            try
            {
                ResponseTopicTwister<WordDTO> response = new ResponseTopicTwister<WordDTO>();
                char startLetter = name[0];
                LetterRepository letterRepository = new LetterRepository();
                Letter letter = new Letter();
                letter = letterRepository.FindByLetter(startLetter);
                if (letter == null) {
                    response.ResponseCode = -1;
                    response.ResponseMessage = "La letra no existe";
                    return response;
                }
                wordRepository = new WordRepository();

                Word word = new Word
                {
                    WordID = Guid.NewGuid().ToString(),
                    WordName = name,
                    LetterID = letter.LetterID
                };

                wordRepository.Create(word);

                response.Dto = new WordDTO
                
                {
                    WordID = word.WordID,
                    WordName = word.WordName,
                    LetterID = word.LetterID 
                };
                return response;
            }
            catch (Exception ex)
            {
                return new ResponseTopicTwister<WordDTO>(null, -1, ex.Message);
            }
        }
        public ResponseTopicTwister<AnswerDTO> VerifyWord(string wordAnswered) {
            // Esto lo cambie por que cuesta mucho integrar con otros servicios

            ResponseTopicTwister<AnswerDTO> response = new ResponseTopicTwister<AnswerDTO>();
            //response = VerifyNull(wordAnswered);
            //if (response.ResponseCode!=0) {
            //    return response;
            //}
            //response = VerifyDigits(wordAnswered);
            //if (response.ResponseCode!=0) {
            //    return response;
            //}
            //return response;
            bool verifyWord = VerifyWordService(wordAnswered);
            if(!verifyWord)
            {
                response.ResponseCode = -1;
                response.ResponseMessage = "La palabra esta vacia o contiene digitos";
            } else
            {
                response.ResponseCode = 0;
            }
            return response;
        }
        public bool VerifyWordService (string wordAnswered)
        {
            bool isOk = VerifyNullService(wordAnswered);
            if (!isOk)
            {
                return isOk;
            }
            /* TODO 
            isOk = VerifyDigitsService(wordAnswered);
            if (!isOk)
            {
                return isOk;
            }*/
            return isOk;
        }
        public bool VerifyNullService(string wordAnswered)
        {
            if (wordAnswered ==null)
            {
                return false;
            }
            return true;
        }
        public bool VerifyDigitsService(string wordAnswered)
        {
            foreach (char ch in wordAnswered)
            {
                if (Char.IsDigit(ch))
                {
                    return false;
                }
            }
            return true;
        }
        public string ConvertToUppercase(string wordAnswered)
        {
            return wordAnswered.ToUpper();
            
        }

        public ResponseTopicTwister<AnswerDTO> VerifyDigits(string wordAnswered)
        {
            ResponseTopicTwister<AnswerDTO> response = new ResponseTopicTwister<AnswerDTO>();
            foreach (char ch in wordAnswered) {
                if (Char.IsDigit(ch)) {
                    response.ResponseCode = -1;
                    response.ResponseMessage = "La palabra contiene dígitos";
                    return response;
                }
                return response;
            }
            throw new NotImplementedException();
        }

        public string ConvertWordBlankSpaces(string actualWord)
        {
            string wordAnswered = actualWord.TrimStart().TrimEnd();
            return wordAnswered;
        }

        public ResponseTopicTwister<AnswerDTO> VerifyNull(string wordAnswered)
        {
            ResponseTopicTwister<AnswerDTO> response = new ResponseTopicTwister<AnswerDTO>();
            if (String.IsNullOrEmpty(wordAnswered)) {
                response.ResponseCode = -1;
                response.ResponseMessage = "La palabra respondida es nula o vacía";
            }
            return response;
        }
    }
}

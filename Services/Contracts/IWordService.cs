using Services.DTOs;
using Services.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IWordService
    {
        public ResponseTopicTwister<WordDTO> CreateWord(string name);
        public ResponseTopicTwister<AnswerDTO> VerifyWord(string wordAnswered);
        public string VerifyAccents(string wordAnswered);
        public bool VerifyWordService(string wordAnswered);
        public bool VerifyNullService(string wordAnswered);
        public bool VerifyDigitsService(string wordAnswered);
        public string ConvertToUppercase(string wordAnswered);
        public ResponseTopicTwister<AnswerDTO> VerifyDigits(string wordAnswered);
        public string ConvertWordBlankSpaces(string actualWord);
        public ResponseTopicTwister<AnswerDTO> VerifyNull(string wordAnswered);
    }
}

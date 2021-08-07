using Services.DTOs;
using Services.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ILetterService
    {
        public ResponseTopicTwister<LetterDTO> CreateLetter(char name);
        public ResponseTopicTwister<List<LetterDTO>> GetAllLetters();
        public ResponseTopicTwister<LetterDTO> GetRandomLetter();
    }
}

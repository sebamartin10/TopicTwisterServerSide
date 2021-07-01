using Models;
using Repository.Contracts;
using Repository.Repos;
using Services.DTOs;
using Services.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class LetterService
    {
        private List<Letter> letterList = new List<Letter>();
        public List<Letter> LetterList => LetterList;

        ILetterRepository letterRepo;
        public ResponseTopicTwister<LetterDTO> CreateLetter(char name)
        {
            try
            {
                ResponseTopicTwister<LetterDTO> response = new ResponseTopicTwister<LetterDTO>();

                Letter letter = new Letter
                {
                    LetterID = Guid.NewGuid().ToString(),
                    LetterName = name
                };

                letterRepo = new LetterRepository();
                letterRepo.Create(letter);

                response.Dto = new LetterDTO

                {
                    LetterID = letter.LetterID,
                    LetterName = letter.LetterName
                };
                return response;
            }
            catch (Exception ex)
            {
                return new ResponseTopicTwister<LetterDTO>(null, -1, ex.Message);
            }
        }

        public ResponseTopicTwister<LetterDTO> GetRandomLetter()
        {
            try
            {
                ResponseTopicTwister<LetterDTO> response = new ResponseTopicTwister<LetterDTO>();
                letterRepo = new LetterRepository();
                letterList = letterRepo.FindAllLetter();
                LetterDTO letterDTO = new LetterDTO();
                Random rdm = new Random();
                List<Letter> letters = new List<Letter>();
                int randomIndex = rdm.Next(0, letterList.Count);
                letters.Add(letterList[randomIndex]);
                letterDTO.LetterID = letterList[randomIndex].LetterID;
                letterDTO.LetterName = letterList[randomIndex].LetterName;
                response.Dto = letterDTO;
                return response;
            }
            catch (Exception ex)
            {
                return new ResponseTopicTwister<LetterDTO>(new LetterDTO(), -1, ex.Message);
            }

        }
    }
}

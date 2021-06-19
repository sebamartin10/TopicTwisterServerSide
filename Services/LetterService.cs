using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class LetterService
    {
        List<char> listOfLetters = new List<char>();
        public List<char> ListOfLetters { get { return listOfLetters; } }
        //char letterSelected;
        public LetterService()
        {
            listOfLetters.AddRange(new List<char>() {
            'a',
            'e',
            'i',
            'o',
            'u'
        });
        }
        public char GetRandomLetter()
        {
            Random rdm = new Random();

            int randomIndex = rdm.Next(0, listOfLetters.Count);
            return listOfLetters[randomIndex];
        }
    }
}

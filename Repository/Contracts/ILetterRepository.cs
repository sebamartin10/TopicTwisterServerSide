using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Contracts
{
    public interface ILetterRepository
    {
        public void Create(Letter letter);
        public void Delete(Letter letter);
        public Letter FindByLetter(char letterName);
        public Letter FindById(string id);
        public List<Letter> FindAllLetter();
    }
}

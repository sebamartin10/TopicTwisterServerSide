using Models;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Repository.Repos
{
    public class LetterRepository : ILetterRepository
    {
        private readonly SQLServerContext context;
        public LetterRepository() {
            context = new SQLServerContext();
        }
        public void Create(Letter letter)
        {
            context.Letters.Add(letter);
            context.SaveChanges();

        }

        public void Delete(Letter letter)
        {
            throw new NotImplementedException();
        }

        public List<Letter> FindAllLetter()
        {
            throw new NotImplementedException();
        }


        public Letter FindByLetter(char letterName)
        {
            throw new NotImplementedException();
        }
    }
}

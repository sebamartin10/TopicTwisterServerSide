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
            context.Letters.Remove(letter);
            context.SaveChanges();
        }

        public List<Letter> FindAllLetter()
        {
            return context.Letters.ToList();
        }
        public Letter FindById(string id)
        {
            Letter letter = (from x in context.Letters
                             where x.LetterID == id
                             select x).FirstOrDefault();
            return letter;
        }

        public Letter FindByLetter(char letterName)
        {
            Letter letter = (from x in context.Letters
                             where x.LetterName == letterName
                             select x).FirstOrDefault();
            return letter;
        }

    }
}

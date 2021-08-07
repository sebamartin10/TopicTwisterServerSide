using Models;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Models.Entities;

namespace Repository.Repos
{
    public class LetterRepository : ILetterRepository
    {
        private readonly ContextDB contexto;
        public LetterRepository(ContextDB contexto) {
            this.contexto = contexto;
        }
        public void Create(Letter letter)
        {
            contexto.Letters.Add(letter);
            contexto.SaveChanges();

        }

        public void Delete(Letter letter)
        {
            contexto.Letters.Remove(letter);
            contexto.SaveChanges();
        }

        public List<Letter> FindAllLetter()
        {
            return contexto.Letters.ToList();
        }
        public Letter FindById(string id)
        {
            Letter letter = (from x in contexto.Letters
                             where x.LetterID == id
                             select x).FirstOrDefault();
            return letter;
        }

        public Letter FindByLetter(char letterName)
        {
            Letter letter = (from x in contexto.Letters
                             where x.LetterName == letterName
                             select x).FirstOrDefault();
            return letter;
        }

    }
}

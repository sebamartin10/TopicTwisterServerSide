using Models;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Models.Entities;

namespace Repository.Repos
{
    public class WordRepository : IWordRepository
    {
        private readonly ContextDB contexto;
        public WordRepository(ContextDB contexto)
        {
            this.contexto = contexto;
        }
        public void Create(Word word)
        {
            contexto.Words.Add(word);
            contexto.SaveChanges();

        }

        public void Delete(Word word)
        {
            contexto.Words.Remove(word);
            contexto.SaveChanges();
        }

        public List<Word> FindAllWord()
        {
            return contexto.Words.ToList();
        }

        public Word FindByWord(string wordName)
        {
            Word word = (from x in contexto.Words
                             where x.WordName == wordName
                             select x).FirstOrDefault();
            return word;
        }
    }
}

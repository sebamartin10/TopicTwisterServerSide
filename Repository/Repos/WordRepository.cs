using Models;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Repository.Repos
{
    public class WordRepository : IWordRepository
    {
        private readonly SQLServerContext context;
        public WordRepository()
        {
            context = new SQLServerContext();
        }
        public void Create(Word word)
        {
            context.Words.Add(word);
            context.SaveChanges();

        }

        public void Delete(Word word)
        {
            throw new NotImplementedException();
        }

        public List<Word> FindAllWord()
        {
            return context.Words.ToList();
        }

        public Word FindByWord(string wordName)
        {
            throw new NotImplementedException();
        }
    }
}

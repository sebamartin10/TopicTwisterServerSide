using Models;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Contracts
{
    public interface IWordRepository
    {
        public void Create(Word word);
        public void Delete(Word word);
        public Word FindByWord(string wordName);
        public List<Word> FindAllWord();
    }
}

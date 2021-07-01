using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Contracts
{
    public interface IWordCategoryRepository
    {
        public void Create(WordCategory wordCategory);
        public void Delete(WordCategory wordCategory);
        public WordCategory FindByWordCategoryID(string WordCategoryID);
        public WordCategory FindByWordAndCategory(string WordID, string CategoryID);
        public List<WordCategory> FindAllWordCategory();
    }
}

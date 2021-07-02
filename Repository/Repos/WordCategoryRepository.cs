using Models;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Repository.Repos
{
    public class WordCategoryRepository : IWordCategoryRepository
    {
        private readonly SQLServerContext context;
        public WordCategoryRepository()
        {
            context = new SQLServerContext();
        }
        public void Create (WordCategory wordCategory)
        {
            context.WordCategories.Add(wordCategory);
            context.SaveChanges();

        }

        public void Delete(WordCategory wordCategory)
        {
            throw new NotImplementedException();
        }

        public List<WordCategory> FindAllWordCategory()
        {
            return context.WordCategories.ToList();
        }

        public WordCategory FindByWordAndCategory(string wordID, string categoryID)
        {
            WordCategory wordCategory = (from x in context.WordCategories
                         where x.WordID == wordID && x.CategoryID == categoryID 
                         select x).FirstOrDefault();
            return wordCategory;
        }

        public WordCategory FindByWordCategoryID(string WordCategoryID)
        {
            WordCategory wordCategory = (from x in context.WordCategories
                                         where x.WordCategoryID == WordCategoryID
                                         select x).FirstOrDefault();
            return wordCategory;
        }
    }
}

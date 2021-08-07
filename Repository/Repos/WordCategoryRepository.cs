using Models;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Models.Entities;

namespace Repository.Repos
{
    public class WordCategoryRepository : IWordCategoryRepository
    {
        private readonly ContextDB contexto;
        public WordCategoryRepository(ContextDB contexto)
        {
            this.contexto = contexto;
        }
        public void Create (WordCategory wordCategory)
        {
            contexto.WordCategories.Add(wordCategory);
            contexto.SaveChanges();

        }

        public void Delete(WordCategory wordCategory)
        {
            throw new NotImplementedException();
        }

        public List<WordCategory> FindAllWordCategory()
        {
            return contexto.WordCategories.ToList();
        }

        public WordCategory FindByWordAndCategory(string wordID, string categoryID)
        {
            WordCategory wordCategory = (from x in contexto.WordCategories
                         where x.WordID == wordID && x.CategoryID == categoryID 
                         select x).FirstOrDefault();
            return wordCategory;
        }

        public WordCategory FindByWordCategoryID(string WordCategoryID)
        {
            WordCategory wordCategory = (from x in contexto.WordCategories
                                         where x.WordCategoryID == WordCategoryID
                                         select x).FirstOrDefault();
            return wordCategory;
        }
    }
}

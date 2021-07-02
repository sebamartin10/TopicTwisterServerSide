using Models;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Repository.Repos
{
    public class RoundCategoryRepository : IRoundCategoryRepository
    {
        private readonly SQLServerContext context;
        public RoundCategoryRepository()
        {
            context = new SQLServerContext();
        }

        public void Create(RoundCategory roundCategory)
        {
            context.RoundCategories.Add(roundCategory);
            context.SaveChanges();
        }

        public void Delete(RoundCategory roundCategory)
        {
            context.RoundCategories.Remove(roundCategory);
            context.SaveChanges();
        }

        public List<RoundCategory> FindAllRoundCategory()
        {
            return context.RoundCategories.ToList();
        }

        public RoundCategory FindByRoundAndCategory(string RoundID, string CategoryID)
        {
            RoundCategory roundCategory = (from x in context.RoundCategories
                                           where x.RoundID == RoundID && x.CategoryID == CategoryID
                                           select x).First();
            return roundCategory;
        }

        public RoundCategory FindByRoundCategoryID(string RoundCategoryID)
        {
            RoundCategory roundCategory = (from x in context.RoundCategories
                                           where x.RoundCategoryID == RoundCategoryID
                                           select x).First();
            return roundCategory;
        }
    }
}

using Models;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Models.Entities;

namespace Repository.Repos
{
    public class RoundCategoryRepository : IRoundCategoryRepository
    {
        private readonly ContextDB contexto;
        public RoundCategoryRepository(ContextDB contexto)
        {
            this.contexto = contexto;
        }

        public void Create(RoundCategory roundCategory)
        {
            contexto.RoundCategories.Add(roundCategory);
            contexto.SaveChanges();
        }

        public void Delete(RoundCategory roundCategory)
        {
            contexto.RoundCategories.Remove(roundCategory);
            contexto.SaveChanges();
        }

        public List<RoundCategory> FindAllRoundCategory()
        {
            return contexto.RoundCategories.ToList();
        }

        public RoundCategory FindByRoundAndCategory(string RoundID, string CategoryID)
        {
            RoundCategory roundCategory = (from x in contexto.RoundCategories
                                           where x.RoundID == RoundID && x.CategoryID == CategoryID
                                           select x).First();
            return roundCategory;
        }

        public List<RoundCategory> FindAllByRound(string RoundID)
        {
            List<RoundCategory> roundCategoryAll = (from x in contexto.RoundCategories
                                                  where x.RoundID == RoundID
                                                  select x).ToList();
            return roundCategoryAll;
        }

        public RoundCategory FindByRoundCategoryID(string RoundCategoryID)
        {
            RoundCategory roundCategory = (from x in contexto.RoundCategories
                                           where x.RoundCategoryID == RoundCategoryID
                                           select x).First();
            return roundCategory;
        }
    }
}

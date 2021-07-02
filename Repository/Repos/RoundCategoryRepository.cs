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
            throw new NotImplementedException();
        }

        public List<RoundCategory> FindAllRoundCategory()
        {
            throw new NotImplementedException();
        }

        public RoundCategory FindByRoundAndCategory(string RoundID, string CategoryID)
        {
            throw new NotImplementedException();
        }

        public RoundCategory FindByRoundCategoryID(string RoundCategoryID)
        {
            throw new NotImplementedException();
        }
}

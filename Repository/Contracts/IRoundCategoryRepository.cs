using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Contracts
{
    public interface IRoundCategoryRepository
    {
        public void Create(RoundCategory roundCategory);
        public void Delete(RoundCategory roundCategory);
        public RoundCategory FindByRoundCategoryID(string RoundCategoryID);
        public RoundCategory FindByRoundAndCategory(string RoundID, string CategoryID);
        public List<RoundCategory> FindAllByRound(string RoundID);
        public List<RoundCategory> FindAllRoundCategory();
    }
}

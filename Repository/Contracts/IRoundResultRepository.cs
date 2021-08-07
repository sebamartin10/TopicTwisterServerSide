using Models;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Contracts
{
    public interface IRoundResultRepository
    {
        public void Create(RoundResult roundResult);
        public List<RoundResult> FindByRound(string roundID);
    }
}

using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Contracts
{
    public interface IRoundRepository
    {
        public void Create(Round round);
        public void Delete(Round round);
        public void Update(Round round);
        //public List<Round> GetAllRoundsBySessionID(string sessionId);
        public Round FindById(string id);
    }
}

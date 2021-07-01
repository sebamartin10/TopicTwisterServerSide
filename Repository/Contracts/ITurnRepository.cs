using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Contracts
{
    public interface ITurnRepository
    {
        public void Create(Turn turn);
        public void Delete(Turn turn);
        public void Update(Turn turn);
        public Turn FindById(string id);
    }
}

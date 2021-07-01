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
<<<<<<< HEAD
        public Turn FindById(string id);
=======
        public Turn FindByTurn(string id);
>>>>>>> f3fb79ae11e9873747f02695f0a64cc5e3267509
    }
}

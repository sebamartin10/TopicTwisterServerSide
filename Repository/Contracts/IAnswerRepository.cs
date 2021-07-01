using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Contracts
{
    public interface IAnswerRepository
    {
        public void Create(Answer answer);
        public void Delete(Answer answer);
        public Answer FindByAnswer(string WordAnswered);
        public List<Answer> FindAllAnswer();
    }
}

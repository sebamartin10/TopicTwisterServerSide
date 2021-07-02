using Models;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Repository.Repos
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly SQLServerContext context;
        public AnswerRepository()
        {
            context = new SQLServerContext();
        }
        public void Create(Answer answer)
        {
            context.Answers.Add(answer);
            context.SaveChanges();
        }

        public void Delete(Answer answer)
        {
            context.Answers.Remove(answer);
            context.SaveChanges();
        }

        public List<Answer> FindAllAnswer()
        {
            throw new NotImplementedException();
        }

        public Answer FindByAnswer(string wordAnswered)
        {
            Answer answer = (from x in context.Answers
                         where x.WordAnswered == wordAnswered
                         select x).FirstOrDefault();
            return answer;
        }
    }
}

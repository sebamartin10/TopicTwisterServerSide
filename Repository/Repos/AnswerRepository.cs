using Models;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Models.Entities;

namespace Repository.Repos
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly ContextDB contexto;
        public AnswerRepository(ContextDB contexto)
        {
            this.contexto = contexto;
        }
        public void Create(Answer answer)
        {
            contexto.Answers.Add(answer);
            contexto.SaveChanges();
        }

        public void Delete(Answer answer)
        {
            contexto.Answers.Remove(answer);
            contexto.SaveChanges();
        }

        public List<Answer> FindAllAnswer()
        {
            throw new NotImplementedException();
        }

        public Answer FindByAnswer(string wordAnswered)
        {
            Answer answer = (from x in contexto.Answers
                         where x.WordAnswered == wordAnswered
                         select x).FirstOrDefault();
            return answer;
        }
    }
}

using Models;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Repository.Repos
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly SQLServerContext context;
        public CategoryRepository() {
            context = new SQLServerContext();
        }
        public void Create(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();

        }

        public void Delete(Category category)
        {
            throw new NotImplementedException();
        }

        public List<Category> FindAllCategory()
        {
            throw new NotImplementedException();
        }

        public Category FindByCategory(string categoryName)
        {
            throw new NotImplementedException();
        }

    }
}

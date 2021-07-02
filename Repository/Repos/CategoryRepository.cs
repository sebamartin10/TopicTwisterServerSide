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
            return context.Categories.ToList();

        }

        public Category FindByCategory(string categoryName)
        {
            Category category = (from x in context.Categories
                             where x.CategoryName == categoryName
                             select x).FirstOrDefault();
            return category;
        }

        public Category FindByCategoryID(string categoryID)
        {
            Category category = (from x in context.Categories
                                 where x.CategoryID == categoryID
                                 select x).FirstOrDefault();
            return category;
        }
    }
}

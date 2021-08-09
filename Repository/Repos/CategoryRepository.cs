using Models;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Models.Entities;

namespace Repository.Repos
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ContextDB contexto;
        public CategoryRepository() { }
        public CategoryRepository(ContextDB contexto) {
            this.contexto = contexto;
        }
        public void Create(Category category)
        {
            contexto.Categories.Add(category);
            contexto.SaveChanges();

        }

        public void Delete(Category category)
        {
            contexto.Categories.Remove(category);
            contexto.SaveChanges();
        }

        public List<Category> FindAllCategory()
        {
            List<Category> categories = contexto.Categories.ToList();
            return categories;
        }

        public Category FindByCategory(string categoryName)
        {
            Category category = (from x in contexto.Categories
                             where x.CategoryName == categoryName
                             select x).FirstOrDefault();
            return category;
        }

        public Category FindByCategoryID(string categoryID)
        {
            Category category = (from x in contexto.Categories
                                 where x.CategoryID == categoryID
                                 select x).FirstOrDefault();
            return category;
        }
    }
}

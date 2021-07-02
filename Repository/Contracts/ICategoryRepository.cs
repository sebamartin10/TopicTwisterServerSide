using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Contracts
{
    public interface ICategoryRepository
    {
        public void Create(Category category);
        public void Delete(Category category);
        public Category FindByCategory(string categoryName);
        public Category FindByCategoryID(string categoryID);
        public List<Category> FindAllCategory();
    }
}

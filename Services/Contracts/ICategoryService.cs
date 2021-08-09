using Models.Entities;
using Repository.Contracts;
using Services.DTOs;
using Services.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ICategoryService
    {
        public ResponseTopicTwister<CategoryDTO> CreateCategory(string name);
        public ResponseTopicTwister<List<CategoryDTO>> GetRandomCategories(int amountOfCategoriesAskedToReturn);
        public ResponseTopicTwister<List<CategoryDTO>> GetAllCategories();
        public Category GetCategory(string categoryId);
        public CategoryDTO ConvertToDTO(Category category);
        public void CreateRepoSubstitute(ICategoryRepository categoryRepository);
    }
}

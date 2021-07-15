using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Repository.Contracts;
using Repository.Repos;
using Services.DTOs;
using Services.Errors;

namespace Services
{
    public class CategoryService
    {
        private List<Category> categoryList = new List<Category>();
        public List<Category> CategoryList => categoryList;

        ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository) {
            this.categoryRepository = categoryRepository;
            categoryList = categoryRepository.FindAllCategory();
        }

        public ResponseTopicTwister<CategoryDTO> CreateCategory(string name)
        {
            try
            {
                ResponseTopicTwister<CategoryDTO> response = new ResponseTopicTwister<CategoryDTO>();

                Category category = new Category
                {
                    CategoryID = Guid.NewGuid().ToString(),
                    CategoryName = name
                };

                categoryRepository.Create(category);

                response.Dto = new CategoryDTO

                {
                    CategoryID = category.CategoryID,
                    CategoryName = category.CategoryName
                };
                return response;
            }
            catch (Exception ex)
            {
                return new ResponseTopicTwister<CategoryDTO>(null, -1, ex.Message);
            }
        }

        public ResponseTopicTwister<List<CategoryDTO>> GetRandomCategories(int amountOfCategoriesAskedToReturn)
        {
          try
            { 
            ResponseTopicTwister<List<CategoryDTO>> response = new ResponseTopicTwister<List<CategoryDTO>>();

            if (amountOfCategoriesAskedToReturn <= 0)
            {
                return new ResponseTopicTwister<List<CategoryDTO>>(new List<CategoryDTO>());
            }

            Random random = new Random();
            List<Category> categories = new List<Category>();

            for (int i = 0; i < amountOfCategoriesAskedToReturn;)
            {
                int randomNumber = random.Next(0, categoryList.Count);
                if (i < categoryList.Count && !categories.Contains(categoryList[randomNumber]))
                {
                    categories.Add(categoryList[randomNumber]);
                    i++;
                }
                else if (i >= categoryList.Count)
                {
                    categories.Add(categoryList[randomNumber]);
                    i++;
                }
            }
            List<CategoryDTO> categoriesDTOs = new List<CategoryDTO>(amountOfCategoriesAskedToReturn);
            for (int i = 0; i < amountOfCategoriesAskedToReturn; i++)
            {
                CategoryDTO categoryDTO = new CategoryDTO();
                categoryDTO.CategoryName = categories[i].CategoryName;
                categoryDTO.CategoryID = categories[i].CategoryID;
                categoriesDTOs.Add(categoryDTO);
            }
            response.Dto = categoriesDTOs;
            return response;
            }
            catch (Exception ex)
            {
                return new ResponseTopicTwister<List<CategoryDTO>>(new List<CategoryDTO>(), -1, ex.Message);
            }
        }

        public ResponseTopicTwister<List<CategoryDTO>> GetAllCategories()
        {
            try
            {
                ResponseTopicTwister<List<CategoryDTO>> response = new ResponseTopicTwister<List<CategoryDTO>>();

                List<CategoryDTO> categoriesDTOs = new List<CategoryDTO>(this.categoryList.Count);
                for (int i = 0; i < this.categoryList.Count; i++)
                {
                    categoriesDTOs.Add(this.ConvertToDTO(this.categoryList[i]));
                }
                response.Dto = categoriesDTOs;
                return response;
            }
            catch (Exception ex)
            {
                return new ResponseTopicTwister<List<CategoryDTO>>(new List<CategoryDTO>(), -1, ex.Message);
            }
        }

        public Category GetCategory(string categoryId)
        {
            Category category = categoryRepository.FindByCategoryID(categoryId);
            return category;
        }

        public CategoryDTO ConvertToDTO(Category category)
        {
            CategoryDTO categoryDTO = new CategoryDTO();
            categoryDTO.CategoryName = category.CategoryName;
            categoryDTO.CategoryID = category.CategoryID;
            return categoryDTO;
        }

        //public List<Category> GetCategories(List<string> categoriesNames)
        //{
        //    List<Category> categories = new List<Category>();
        //    for (int i = 0; i < categoriesNames.Count; i++)
        //    {
        //        foreach (var category in categoryList)
        //        {
        //            if (category.CategoryName == categoriesNames[i])
        //            {
        //                categories.Add(category);
        //            }
        //        }
        //    }
        //    return categories;
        //}

        //public List<string> GetCategoriesNames(List<Category> categories)
        //{
        //    List<string> categoriesName = new List<string>();
        //    foreach (Category category in categories)
        //    {
        //        categoriesName.Add(category.CategoryName);
        //    }
        //    return categoriesName;
        //}


    }
}

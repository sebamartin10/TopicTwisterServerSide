using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Services.DTOs;

namespace Services
{
    public class CategoryService
    {
        private List<Category> categoryList = new List<Category>();
        public List<Category> CategoryList => categoryList;
       
        public CategoryService()
        {
            //TODO - Traer desde base de datos
            categoryList.Add(new Category("Objeto"));
            categoryList.Add(new Category("Cine"));
            categoryList.Add(new Category("Musica"));
            categoryList.Add(new Category("Animal"));
            categoryList.Add(new Category("Fruta o Verdura"));
        }

        private CategoryDTO CreateCategoryDTO(Category category)
        {
            CategoryDTO categoryDTO = new CategoryDTO

            {
                CategoryID = category.CategoryID,
                CategoryName = category.CategoryName
            };
            return categoryDTO;
        }

        public List<CategoryDTO> GetRandomCategories(int amountOfCategoriesAskedToReturn)
        {
            if (amountOfCategoriesAskedToReturn <= 0)
            {
                return new List<CategoryDTO>();
            }

            Random random = new Random();
            List<Category> categories = new List<Category>(amountOfCategoriesAskedToReturn);

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
                CategoryDTO categoryDTO = CreateCategoryDTO(categories[i]);
                categoriesDTOs.Add(categoryDTO);
            }
            return categoriesDTOs;
        }

        public List<Category> GetCategories(List<string> categoriesNames)
        {
            List<Category> categories = new List<Category>();
            for (int i = 0; i < categoriesNames.Count; i++)
            {
                foreach (var category in categoryList)
                {
                    if (category.CategoryName == categoriesNames[i])
                    {
                        categories.Add(category);
                    }
                }
            }
            return categories;
        }

        public List<string> GetCategoriesNames(List<Category> categories)
        {
            List<string> categoriesName = new List<string>();
            foreach (Category category in categories)
            {
                categoriesName.Add(category.CategoryName);
            }
            return categoriesName;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryService
    {
        public List<string> CategoryList => categoryList;
        List<string> categoryList = new List<string>();
        public CategoryService()
        {
            //TODO - Traer desde base de datos
            categoryList.Add("Objeto");
            categoryList.Add("Cine");
            categoryList.Add("Musica");
            categoryList.Add("Animal");
            categoryList.Add("Fruta o Verdura");
        }

        public List<String> GetRandomCategoriesName(int amountOfCategoriesAskedToReturn)
        {
            Random random = new Random();
            List<string> randomCategories = new List<string>();

            for (int i = 0; i < amountOfCategoriesAskedToReturn;)
            {
                int randomNumber = random.Next(0, categoryList.Count);
                if (i < categoryList.Count && !randomCategories.Contains(categoryList[randomNumber]))
                {
                    randomCategories.Add(categoryList[randomNumber]);
                    i++;
                }
                else if (i >= categoryList.Count)
                {
                    randomCategories.Add(categoryList[randomNumber]);
                    i++;
                }

            }


            return randomCategories;
        }
    }
}

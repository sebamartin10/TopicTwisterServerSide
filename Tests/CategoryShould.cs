using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Services;
using Services.Errors;

namespace Tests
{
    class CategoryShould
    {
        CategoryService categoryService;

        [SetUp]
        public void Before()
        {
            //given
            categoryService = new CategoryService();
        }

        [Test]

        public void ReturnThreeCategoriesNames()
        {
            //given
            int value = 3;

            //when
            int amount = categoryService.GetRandomCategoriesName(value).Count;

            //assert
            Assert.AreEqual(value, amount);
        }

        [Test]

        public void NotRepeatCategoryNamesIfAmountOfCategoriesIsGreaterThanAmountAsk()
        {
            //When
            List<string> categoriesName = categoryService.GetRandomCategoriesName(5);
            //Assert
            Assert.AreNotEqual(categoriesName[0], categoriesName[1]);
            Assert.AreNotEqual(categoriesName[0], categoriesName[2]);
            Assert.AreNotEqual(categoriesName[1], categoriesName[2]);
            Assert.AreNotEqual(categoriesName[0], categoriesName[3]);
            Assert.AreNotEqual(categoriesName[1], categoriesName[3]);
            Assert.AreNotEqual(categoriesName[2], categoriesName[3]);
            Assert.AreNotEqual(categoriesName[0], categoriesName[4]);
            Assert.AreNotEqual(categoriesName[1], categoriesName[4]);
            Assert.AreNotEqual(categoriesName[2], categoriesName[4]);
            Assert.AreNotEqual(categoriesName[3], categoriesName[4]);
        }

        [Test]

        public void RepeatCategoryNamesIfAmountOfCategoriesIsLowerThanAmountAsk()
        {
            //When
            List<string> categoriesName = categoryService.GetRandomCategoriesName(categoryService.CategoryList.Count + 1);
            List<string> categoriesAuxiliar = categoriesName;
            categoriesAuxiliar.RemoveAt(categoriesAuxiliar.Count - 1);

            //Assert
            Assert.IsTrue(categoriesAuxiliar.Contains(categoriesName[categoriesName.Count - 1]));
        }

        [TestCase(0)]
        [TestCase(-1)]

        public void ReturnEmptyList(int amountOfCategories)
        {
            //When
            List<string> categoriesName = categoryService.GetRandomCategoriesName(amountOfCategories);
            //Assert
            Assert.AreEqual(0, categoriesName.Count);

        }
    }
}

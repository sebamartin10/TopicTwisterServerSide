using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.Entities;
using NSubstitute;
using NUnit.Framework;
using Repository.Contracts;
using Services;
using Services.DTOs;
using Services.Errors;

namespace Tests
{
    class CategoryShould
    {
        CategoryService services;
        ICategoryRepository repository;

        [SetUp]
        public void Before() {
            repository = Substitute.For<ICategoryRepository>();
            repository.FindAllCategory().Returns(new List<Category>() {
                new Category(){CategoryName = "Cat1"},
                new Category(){CategoryName = "Cat2"},
                new Category(){CategoryName = "Cat3"},
                new Category(){CategoryName = "Cat4"},
                new Category(){CategoryName = "Cat5"}
            });

            services = new CategoryService(repository);
        }

        [Test]

        public void ReturnThreeCategories()
        {
            //given
            int value = 3;

            //when
            int amount = services.GetRandomCategories(value).Dto.Count;

            //assert
            Assert.AreEqual(value, amount);
        }

        [Test]

        public void NotRepeatCategoryNamesIfAmountOfCategoriesIsGreaterThanAmountAsk()
        {
            //When
            List<CategoryDTO> categoriesName = services.GetRandomCategories(5).Dto;
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

        public void RepeatCategoryNamesIfAmountOfCategoriesIsLowerThanAmountAsk() {
            //When
            List<CategoryDTO> categoriesName = services.GetRandomCategories(services.CategoryList.Count + 1).Dto;
            List<CategoryDTO> categoriesAuxiliar = categoriesName;
            categoriesAuxiliar.RemoveAt(categoriesAuxiliar.Count - 1);
            //Assert
            Assert.IsTrue(categoriesAuxiliar.Contains(categoriesName[categoriesName.Count - 1]));
        }

        [TestCase(0)]
        [TestCase(-1)]

        public void ReturnEmptyList(int amountOfCategories)
        {
            //When
            List<CategoryDTO> categoriesName = services.GetRandomCategories(amountOfCategories).Dto;
            //Assert
            Assert.AreEqual(0, categoriesName.Count);
        }
    }
}

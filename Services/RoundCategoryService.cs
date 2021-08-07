using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.Entities;
using Repository.Contracts;
using Repository.Repos;
using Services.DTOs;
using Services.Errors;

namespace Services
{
    public class RoundCategoryService
    {
        IRoundCategoryRepository roundCategoryRepository;


        public ResponseTopicTwister<RoundCategoryDTO> CreateRoundCategory(string roundID, string categoryID)
        {
            try
            {
                ResponseTopicTwister<RoundCategoryDTO> response = new ResponseTopicTwister<RoundCategoryDTO>();
                
                roundCategoryRepository = new RoundCategoryRepository();
                
                Category category = new Category();
                CategoryRepository categoryRepository = new CategoryRepository();
                category = categoryRepository.FindByCategoryID(categoryID);

                Round round = new Round();
                RoundRepository roundRepository = new RoundRepository();
                round = roundRepository.FindById(roundID);

                RoundCategory roundCategory = new RoundCategory
                {
                    RoundCategoryID = Guid.NewGuid().ToString(),
                    RoundID = round.RoundID,
                    CategoryID = category.CategoryID
                };

                roundCategoryRepository.Create(roundCategory);

                response.Dto = new RoundCategoryDTO
                
                {
                    RoundCategoryID = Guid.NewGuid().ToString(),
                    RoundID = round.RoundID,
                    CategoryID = category.CategoryID
                };
                return response;
            }
            catch (Exception ex)
            {
                return new ResponseTopicTwister<RoundCategoryDTO>(null, -1, ex.Message);
            }
        }

        public RoundCategoryDTO ConvertToDTO(RoundCategory roundCategory)
        {
            RoundCategoryDTO roundCategoryDto = new RoundCategoryDTO
            {
                RoundCategoryID = Guid.NewGuid().ToString(),
                RoundID = roundCategory.RoundID,
                CategoryID = roundCategory.CategoryID
            };
            return roundCategoryDto;
        }

     }
}

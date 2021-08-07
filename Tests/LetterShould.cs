using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using Services;
using Services.Contracts;

namespace Tests
{
    class LetterShould
    {
        [Test]
        public void Return_A_Letter()
        {
            //Given
            ILetterService letterService = Substitute.For<ILetterService>();
            //LetterService letterService = new LetterService();
            //When
            char letter = letterService.GetRandomLetter().Dto.LetterName;
            //Assert
            Assert.IsNotNull(letter);
        }

    }
}

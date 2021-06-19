using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Services;

namespace Tests
{
    class LetterShould
    {
        [Test]
        public void Return_A_Letter()
        {
            //Given
            LetterService letterService = new LetterService();
            //When
            char letter = letterService.GetRandomLetter();
            //Assert
            Assert.IsNotNull(letter);
        }

    }
}

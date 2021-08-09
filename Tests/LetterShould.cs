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
        [TestCase('a',true)]
        [TestCase('6',false)]
        [TestCase('@',false)]
        [TestCase('\\',false)]
        [TestCase('A',true)]
        public void Return_A_Letter()
        {
            //Given
            //ILetterService letterService = Substitute.For<ILetterService>();
            LetterService letterService = new LetterService();
            //When
            
            //Assert
            Assert.IsNotNull(letter);
        }
        [Test]
        public void Not_Be_Empty() {
            //Given
            char letter = ' ';
            LetterService letterService = new LetterService();
            //When
            bool result = letterService.VerifyEmptyLetter(letter);
            //Then
            Assert.IsFalse(result);

        }

    }
}

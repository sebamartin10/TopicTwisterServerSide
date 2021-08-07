using NUnit.Framework;
using Services;
using Services.Errors;
using Services.DTOs;
using NSubstitute;
using Services.Contracts;
using Repository.Contracts;
using Models;

namespace Tests
{
    public class WordShould
    {
        [Test]
        public void Word_Answered_Not_Empty() {
            //Given
            string wordAnswered = "TopicTwister";
            ResponseTopicTwister<AnswerDTO> response = new ResponseTopicTwister<AnswerDTO>();
           
            WordService wordService = new WordService();
            //When
            response = wordService.VerifyNull(wordAnswered);
            //Then
            Assert.AreEqual(0, response.ResponseCode);

        }
        [TestCase("word","WORD")]
        [TestCase("Word","WORD")]
        [TestCase("worD","WORD")]
        [TestCase("wORd","WORD")]
        [TestCase("WorD","WORD")]
        public void Word_Answered_Must_Be_In_Uppercase(string actualWord, string expectedWord) {
            //Given
       
            WordService wordService = new WordService();
            //When
            string word = wordService.ConvertToUppercase(actualWord);
            //Then
            Assert.AreEqual(expectedWord,word);
        }
        [Test]
        public void Word_Answered_Must_Not_Have_Digits() {
            //Given
            string wordAnswered = "TOPICTWISTER";
            ResponseTopicTwister<AnswerDTO> response = new ResponseTopicTwister<AnswerDTO>();
            
            WordService wordService = new WordService();
            //When
            response = wordService.VerifyDigits(wordAnswered);
            //Then
            Assert.AreEqual(0,response.ResponseCode);
        }
        [TestCase(" WORD1 WORD2 ","WORD1 WORD2")]
        [TestCase("    WORD","WORD")]
        [TestCase("WORD     ","WORD")]
        [TestCase("   WORD   ","WORD")]
        public void Not_Has_Blank_Spaces_At_The_Beginning_And_The_End(string actualWord,string expectedWord) {
            //Given
            WordService wordService = new WordService();
            //When
            string word = wordService.ConvertWordBlankSpaces(actualWord);
            //Then
            Assert.AreEqual(expectedWord, word);
        }
        [TestCase("áéíóú","aeiou")]
        [TestCase("aé io ú","ae io u")]
        [TestCase("ÁÁÁ","AAA")]
        [TestCase("", "")]
        [TestCase("ÚGANDA", "UGANDA")]
        [TestCase("España","España")]
        public void Word_Answered_Must_Have_No_Accents(string wordAnswered,string wordExpected) {
            //Given
            //IWordService wordService = Substitute.For<IWordService>();
            WordService wordService = new WordService();
            //When
            string wordActual = wordService.VerifyAccents(wordAnswered);
            //Then
            Assert.AreEqual(wordExpected, wordActual);
        }
        [TestCase("España","España")]
        [TestCase("Ñoqui","Ñoqui")]
        [TestCase("Año","Año")]
        public void Word_Answered_Must_Accept_Ñ(string wordAnswered, string wordExpected) {
            
            WordService wordService = new WordService();
            //When
            string wordActual = wordService.VerifyAccents(wordAnswered);
            //Then
            Assert.AreEqual(wordExpected, wordActual);
        }
    }
}
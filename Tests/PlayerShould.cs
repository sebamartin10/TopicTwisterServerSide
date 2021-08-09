using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using NSubstitute;
using NUnit.Framework;
using Repository.Contracts;
using Services;
using Services.Contracts;
using Services.DTOs;
using Services.Errors;

namespace Tests
{
    public class PlayerShould
    {
        IPlayerService playerService;
        [SetUp]
        public void Before() {
            playerService = new PlayerService();
        }

        [TestCase("abcd",0)]
        [TestCase("abc",-1)]
        [TestCase("abcd9080",0)]
        [TestCase("abcdASX",0)]
        [TestCase("",-1)]
        [TestCase("a",-1)]
        [TestCase("12",-1)]
        public void Write_A_Name_With_At_Least_4_Letters(string name, int expected)
        {
            //Given
            //PlayerService playerService = new PlayerService();
            //When
            ResponseTopicTwister<PlayerDTO> result = playerService.VerifyName(name);
            //Then
            Assert.AreEqual(expected, result.ResponseCode);
        }

        [TestCase("abcd", 0)]
        [TestCase("abc", -1)]
        [TestCase("abcd9080", 0)]
        [TestCase("abcdASX", 0)]
        [TestCase("a%$#X", 0)]
        [TestCase("abcd$ASX", 0)]
        [TestCase("", -1)]
        [TestCase("a", -1)]
        [TestCase("12", -1)]
        public void Write_A_Pass_With_At_Least_4_Caracters(string password, int expected)
        {
            //Given
            //PlayerService playerService = new PlayerService();
            //When
            ResponseTopicTwister<PlayerDTO> result = playerService.VerifyPass(password);
            //Then
            Assert.AreEqual(expected, result.ResponseCode);
        }

        [TestCase("abcd", 0)]
        [TestCase("abcYTRYTdfdvcvc", -1)]
        [TestCase("abcd9080", 0)]
        [TestCase("abcdASX", 0)]
        [TestCase("a%$#X", 0)]
        [TestCase("abcd$ASX", 0)]

        public void Write_A_Pass_With_Max_Ten_Caracters(string password, int expected)
        {
            //Given
            //PlayerService playerService = new PlayerService();
            //When
            ResponseTopicTwister<PlayerDTO> result = playerService.VerifyPass(password);
            //Then
            Assert.AreEqual(expected, result.ResponseCode);
        }

       

    }
}

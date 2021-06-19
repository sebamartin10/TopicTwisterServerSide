﻿using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Services;
using Services.Errors;

namespace Tests
{
    public class PlayerShould
    {
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
            PlayerService playerService = new PlayerService();
            //When
            ResponseTopicTwister result = PlayerService.VerifyName(name);
            //Then
            Assert.AreEqual(expected, result.ResponseCode);
        }
    }
}

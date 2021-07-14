using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Services;
using Services.DTOs;
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
            ResponseTopicTwister<PlayerDTO> result = PlayerService.VerifyName(name);
            //Then
            Assert.AreEqual(expected, result.ResponseCode);
        }
        [Test]
        public void Prove_Identity_With_User_And_Password() {
            //Given
            PlayerService playerService = new PlayerService();
            
            PlayerDTO playerDTO = new PlayerDTO
            {
                playerName="Player",
                password="Pass"
            };
            //When
            ResponseTopicTwister<PlayerDTO> playerDTOLogin = playerService.Login(playerDTO);
            //Then
            Assert.AreEqual(playerDTO.playerName, playerDTOLogin.Dto.playerName);
            Assert.AreEqual(playerDTO.password, playerDTOLogin.Dto.password);
        }
    }
}

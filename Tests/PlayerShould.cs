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
            PlayerService playerService = new PlayerService();
            //When
            ResponseTopicTwister<PlayerDTO> result = PlayerService.VerifyPass(password);
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
            PlayerService playerService = new PlayerService();
            //When
            ResponseTopicTwister<PlayerDTO> result = PlayerService.VerifyPass(password);
            //Then
            Assert.AreEqual(expected, result.ResponseCode);
        }

        [Test]
        public void Register_A_Player()
        {
            //Given
            PlayerService playerService = new PlayerService();
            PlayerDTO playerDTO = new PlayerDTO();
            playerDTO.playerName = "Player1";
            playerDTO.password = "pass123";
            playerDTO.playerID = Guid.NewGuid().ToString();
            //When
            ResponseTopicTwister<PlayerDTO> result = playerService.RegisterPlayer(playerDTO.playerName, playerDTO.password, playerDTO.playerID);
            //Then
            Assert.AreEqual(playerDTO.playerID, result.Dto.playerID);
        }

        [Test]
        public void Prove_Identity_With_User_And_Password() {

            //Given
            PlayerService playerService = new PlayerService();

            PlayerDTO playerDTO = new PlayerDTO {
                playerName = "Player",
                password = "Pass"
            };
            //When
            ResponseTopicTwister<PlayerDTO> playerDTOLogin = playerService.Login(playerDTO);
            //Then
            Assert.AreEqual(playerDTO.playerName, playerDTOLogin.Dto.playerName);
            Assert.AreEqual(playerDTO.password, playerDTOLogin.Dto.password);
        }
    }
}

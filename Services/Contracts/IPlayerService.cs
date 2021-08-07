using Services.DTOs;
using Services.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IPlayerService
    {
        public PlayerDTO GetOpponent(string playerID);
        public ResponseTopicTwister<PlayerDTO> Login(PlayerDTO playerDTO);
        public ResponseTopicTwister<PlayerDTO> VerifyName(string name);
        public ResponseTopicTwister<PlayerDTO> VerifyPlayerDuplicated(string name, string password);
        public ResponseTopicTwister<PlayerDTO> RegisterPlayer(string name, string password, string id);
        public ResponseTopicTwister<PlayerDTO> VerifyPass(string password);
    }
}

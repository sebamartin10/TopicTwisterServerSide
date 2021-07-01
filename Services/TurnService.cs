using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.DTOs;
using Services.Errors;
using Models;
using Repository.Contracts;
using Repository.Repos;

namespace Services
{
    public class TurnService
    {
        private TurnRepository turnRepository;
        public ResponseTopicTwister<TurnDTO> CreateTurn(string playerId, string roundId)
        {
            try
            {
                ResponseTopicTwister<TurnDTO> responseTurn = new ResponseTopicTwister<TurnDTO>();
                //RoundRepository roundRepository = new RoundRepository();
                //Round round = new Round();
                //round = roundRepository.FindById(roundId);
                PlayerRepository playerRepository = new PlayerRepository();
                Player player = new Player();
                player = playerRepository.FindByUser(playerId);
                //if (round == nul)
                //{
                //    responseTurn.ResponseCode = -1;
                //    responseTurn.ResponseMessage = "La ronda no existe";
                //    return responseTurn;
                //}
                if (player == null)
                {
                    responseTurn.ResponseCode = -1;
                    responseTurn.ResponseMessage = "El usuario no existe";
                    return responseTurn;
                }
                turnRepository = new TurnRepository();
                Turn turn = new Turn
                {
                    TurnID = Guid.NewGuid().ToString(),
                    PlayerID = playerId,
                    RoundID = roundId,
                    Player = player
                };

                turnRepository.Create(turn);

                responseTurn.Dto = new TurnDTO

                {
                    TurnID = turn.TurnID,
                    PlayerID = turn.PlayerID,
                    RoundID = turn.RoundID,
                    Answers = new List<string>()
                };
                return responseTurn;
            }
            catch (Exception ex)
            {
                return new ResponseTopicTwister<TurnDTO>(null, -1, ex.Message);
            }
        }
        //public static void FinishTurn(float time, List<Word> words, Round round)
        //{

        //}
    }
}

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
        public Turn CreateTurn(Player player, string playerId, string roundId)
        {
            try
            {
                turnRepository = new TurnRepository();
                Turn turn = new Turn
                {
                    TurnID = Guid.NewGuid().ToString(),
                    PlayerID = playerId,
                    RoundID = roundId,
                    Player = player
                };

                turnRepository.Create(turn);

                return turn;
            }
            catch
            {
                return null;
            }
        }
        public TurnDTO ConvertToDTO(Turn turn)
        {
            TurnDTO turnDto = new TurnDTO
            {
                TurnID = turn.TurnID,
                PlayerID = turn.PlayerID,
                RoundID = turn.RoundID,
                Answers = new List<string>()
            };
            return turnDto;
        }
        //public static void FinishTurn(float time, List<Word> words, Round round)
        //{

        //}
    }
}

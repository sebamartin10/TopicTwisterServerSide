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
        private AnswerService answerService;

        public TurnService() {
            this.answerService = new AnswerService();
        }

        public Turn CreateTurn(Player player, string roundId) {
            turnRepository = new TurnRepository();
            Turn turn = new Turn {
                TurnID = Guid.NewGuid().ToString(),
                PlayerID = player.PlayerID,
                RoundID = roundId,
                //Player = player,
                Answers = new List<Answer>()
            };

            turnRepository.Create(turn);

            turn.Player = player;

            return turn;
        }

        public TurnDTO ConvertToDTO(Turn turn) {
            List<AnswerDTO> answersListDto = new List<AnswerDTO>();
            if (turn.Answers != null) {
                foreach (var answer in turn.Answers) {
                    answersListDto.Add(answerService.ConvertToDTO(answer));
                }
            }
            TurnDTO turnDto = new TurnDTO {
                TurnID = turn.TurnID,
                PlayerID = turn.PlayerID,
                //RoundID = turn.RoundID,
                Answers = answersListDto,
                Finished = false, //ToDo Finished
                FinishTime = 0, //ToDo FinishTime
                CorrentAnswers = 0 //Todo CorrectAnsers

            };
            return turnDto;
        }
        //public static void FinishTurn(float time, List<Word> words, Round round)
        //{

        //}
    }
}

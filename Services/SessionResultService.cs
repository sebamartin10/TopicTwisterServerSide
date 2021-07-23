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
using Services.Enums;

namespace Services
{
    public class SessionResultService
    {
        SessionRepository sessionRepository;
        RoundRepository roundRepository;
        RoundResultRepository roundResultRepository;
        PlayerSessionRepository playerSessionRepository;
        PlayerRepository playerRepository;

        bool player1Win = false;
        bool player2Win = false;
        int player1Result = 0;
        int player2Result = 0;
        public ResponseTopicTwister<SessionResultDTO> GetSessionResult(string idSession)
        {
            try
            {
                ResponseTopicTwister<SessionResultDTO> responseSessionResult = new ResponseTopicTwister<SessionResultDTO>();
                sessionRepository = new SessionRepository();
                Session session = sessionRepository.FindById(idSession);

                roundRepository = new RoundRepository();
                List<Round> rounds = roundRepository.FindBySession(idSession);

                roundResultRepository = new RoundResultRepository();
                List<RoundResult> roundResults = new List<RoundResult>();

                foreach (Round round in rounds)
                {
                    roundResults.AddRange(roundResultRepository.FindByRound(round.RoundID));   
                }
                
                Player player1 = roundResults[0].Player;
                Player player2 = roundResults[1].Player;

                foreach(RoundResult roundResult in roundResults)
                {
                    if(roundResult.Player.PlayerID == player1.PlayerID)
                    {
                        if(roundResult.StatusPlayer == (int)PlayerEnum.Win)
                        {
                            player1Result ++;
                        }
                    }
                    else if (roundResult.Player.PlayerID == player2.PlayerID)
                    {
                        if (roundResult.StatusPlayer == (int)PlayerEnum.Win)
                        {
                            player2Result ++;
                        }
                    }
                }

                if (player1Result == player2Result) 
                {
                    player1Win = true;
                    player2Win = true;
                }
                else if(player1Result > player2Result)
                {
                    player1Win = true;
                }
                else
                {
                    player2Win = true;
                }

                if (!rounds[0].Finished || !rounds[1].Finished || !rounds[2].Finished)
                {
                    player1Win = false;
                    player2Win = false;
                }

                SessionResultDTO sessionResultDTO = new SessionResultDTO()
                {
                    SessionID = idSession,
                    Player1Name = player1.PlayerName,
                    Player2Name = player2.PlayerName,
                    Player1Result = player1Result,
                    Player2Result = player2Result,
                    isPlayer1Winner = player1Win,
                    isPlayer2Winner = player2Win
                };

                responseSessionResult.Dto = sessionResultDTO;


                SessionResultRepository sessionResultRepository = new SessionResultRepository();
                if (sessionResultRepository.FindBySession(idSession).Count == 0) {

                    SessionResult sessionResultPlayer1 = new SessionResult() {
                        SessionResultID = Guid.NewGuid().ToString(),
                        SessionID = idSession,
                        PlayerID = player1.PlayerID,
                        StatusPlayer = player1Win ? (int)PlayerEnum.Win : (int)PlayerEnum.Lost
                    };

                    SessionResult sessionResultPlayer2 = new SessionResult() {
                        SessionResultID = Guid.NewGuid().ToString(),
                        SessionID = idSession,
                        PlayerID = player2.PlayerID,
                        StatusPlayer = player2Win ? (int)PlayerEnum.Win : (int)PlayerEnum.Lost
                    };

                    sessionResultRepository.Create(sessionResultPlayer1);
                    sessionResultRepository.Create(sessionResultPlayer2);
                }

                return responseSessionResult;
            }
            catch (Exception ex)
            {
                return new ResponseTopicTwister<SessionResultDTO>(null, -1, ex.Message);
            }
        }

    }
}

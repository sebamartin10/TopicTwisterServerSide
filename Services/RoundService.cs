﻿using System;
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
    public class RoundService
    {
        private RoundRepository roundRepository;
        private TurnService turnService;

        public RoundService()
        {
            this.turnService = new TurnService();
        }

        private Player CheckPlayer(string playerId)
        {
            PlayerRepository playerRepository = new PlayerRepository();
            Player player = new Player();
            player = playerRepository.FindByUser(playerId);
            return player;
        }
        private Session CheckSession(string sessionId)
        {
            SessionRepository sessionRepository = new SessionRepository();
            Session session = new Session();
            session = sessionRepository.FindById(sessionId);
            return session;
        }
        private Letter CheckLetter(string letterId)
        {
            LetterRepository letterRepository = new LetterRepository();
            Letter letter = new Letter();
            letter = letterRepository.FindById(letterId);
            return letter;
        }

        public ResponseTopicTwister<RoundDTO> CreateRound(string player1Id, string player2Id, string sessionId)
        {
            try
            {
                ResponseTopicTwister<RoundDTO> responseRound = new ResponseTopicTwister<RoundDTO>();
                PlayerRepository playerRepository = new PlayerRepository();
                Player player1 = CheckPlayer(player1Id);
                Player player2 = CheckPlayer(player2Id);
                Session session = CheckSession(sessionId);
                if (player1 == null)
                {
                    responseRound.ResponseCode = -1;
                    responseRound.ResponseMessage = "El jugaror 1 no existe";
                    return responseRound;
                }
                if (player2 == null)
                {
                    responseRound.ResponseCode = -1;
                    responseRound.ResponseMessage = "El jugaror 2 no existe";
                    return responseRound;
                }
                if (session == null)
                {
                    responseRound.ResponseCode = -1;
                    responseRound.ResponseMessage = "La sesion no existe";
                    return responseRound;
                }
                roundRepository = new RoundRepository();
                Round round = new Round
                {
                    RoundID = Guid.NewGuid().ToString(),
                    SessionID = sessionId
                };
                roundRepository.Create(round);

                Round restoredRound = roundRepository.FindById(round.RoundID);

                if(restoredRound == null)
                {
                    responseRound.ResponseCode = -1;
                    responseRound.ResponseMessage = "No se pudo recuperar la ronda";
                    return responseRound;
                }

                Turn turn1 = turnService.CreateTurn(player1, player1Id, restoredRound.RoundID);
                Turn turn2 = turnService.CreateTurn(player2, player2Id, restoredRound.RoundID);
                if (turn1 == null || turn2 == null)
                {
                    responseRound.ResponseCode = -1;
                    responseRound.ResponseMessage = "Los turnos no pudieron ser creados";
                    return responseRound;
                }

                responseRound.Dto = this.ConvertToDTO(restoredRound);
                return responseRound;
            }
            catch (Exception ex)
            {
                return new ResponseTopicTwister<RoundDTO>(null, -1, ex.Message);
            }
        }
        public RoundDTO ConvertToDTO(Round round)
        {
            List<TurnDTO> turnsListDto = new List<TurnDTO>();
            foreach (var turn in round.Turns)
            {
                turnsListDto.Add(turnService.ConvertToDTO(turn));
            }
            RoundDTO roundDto = new RoundDTO
            {
                RoundID = round.RoundID,
                SessionID = round.SessionID,
                LetterID = round.LetterID,
                Turns = turnsListDto
            };
            return roundDto;
        }
        public ResponseTopicTwister<RoundDTO> AddLetter(string roundId, string letterId)
        {
            try
            {
                ResponseTopicTwister<RoundDTO> responseRound = new ResponseTopicTwister<RoundDTO>();
                roundRepository = new RoundRepository();
                Round round = new Round();
                round = roundRepository.FindById(roundId);
                if (round == null)
                {
                    responseRound.ResponseCode = -1;
                    responseRound.ResponseMessage = "La ronda no existe";
                    return responseRound;
                }
                Letter letter = CheckLetter(letterId);
                if (letter == null)
                {
                    responseRound.ResponseCode = -1;
                    responseRound.ResponseMessage = "La letra no existe";
                    return responseRound;
                }
                round.LetterID = letter.LetterID;
                roundRepository.Update(round);
                responseRound.Dto = this.ConvertToDTO(round);
                return responseRound;
            } catch (Exception ex)
            {
                return new ResponseTopicTwister<RoundDTO>(null, -1, ex.Message);
            }
        }
    }
}
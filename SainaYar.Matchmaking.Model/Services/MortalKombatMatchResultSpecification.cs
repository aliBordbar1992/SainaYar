using System;
using System.Collections.Generic;
using SainaYar.Matchmaking.Core.DTO;
using SainaYar.Matchmaking.Core.Interfaces;
using SainaYar.Matchmaking.Core.Model;

namespace SainaYar.Matchmaking.Core.Services
{
    public class MortalKombatMatchResultSpecification<T> : IMatchResultSpecification<T> where T : Player
    {
        public readonly int MaxRounds = 3;

        private readonly ParticipantSpecs<T> _firstParticipant;
        private readonly ParticipantSpecs<T> _secondParticipant;

        public MortalKombatMatchResultSpecification(ParticipantSpecs<T> firstPlayerSpecs, ParticipantSpecs<T> secondPlayerSpecs)
        {
            _firstParticipant = firstPlayerSpecs;
            _secondParticipant = secondPlayerSpecs;
        }

        public MatchResult<T> GetResult(Guid matchId, Guid gameId)
        {
            var winner = GetWinner();
            var loser = GetLoser();


            var matchResult = new MatchResult<T>(Guid.NewGuid(), matchId, gameId);


            SetWinner(matchId, gameId, winner, loser, matchResult);
            SetLoser(matchId, gameId, loser, winner, matchResult);

            return matchResult;
        }

        private void SetWinner(Guid matchId, Guid gameId, ParticipantSpecs<T> winner, ParticipantSpecs<T> loser, MatchResult<T> matchResult)
        {
            var winnerResultScores =
                new ResultScore<T>(
                    winner.Participant,
                    matchId,
                    gameId,
                    winner.RoundsWon,
                    loser.RoundsWon);

            var winnerCalculator = new MortalKombatPointCalculator(
                MaxRounds,
                winner.RoundsWon,
                loser.PreviousScore,
                winner.PreviousScore);

            winnerResultScores.SetPointsTaken(winnerCalculator);
            winnerResultScores.SetPointsLost(winnerCalculator);

            matchResult.SetWinner(winnerResultScores);
        }
        private void SetLoser(Guid matchId, Guid gameId, ParticipantSpecs<T> loser, ParticipantSpecs<T> winner, MatchResult<T> matchResult)
        {
            var loserResultScores =
                new ResultScore<T>(
                    loser.Participant,
                    matchId,
                    gameId,
                    loser.RoundsWon,
                    winner.RoundsWon);

            var loserCalculator = new MortalKombatPointCalculator(
                MaxRounds,
                loser.RoundsWon,
                winner.PreviousScore,
                loser.PreviousScore);

            loserResultScores.SetPointsTaken(loserCalculator);
            loserResultScores.SetPointsLost(loserCalculator);

            matchResult.SetLoser(loserResultScores);
        }


        private ParticipantSpecs<T> GetWinner()
        {
            if (_firstParticipant.RoundsWon == MaxRounds)
                return _firstParticipant;

            if (_secondParticipant.RoundsWon == MaxRounds)
                return _secondParticipant;

            throw new ArgumentNullException($"no winner found");
        }
        private ParticipantSpecs<T> GetLoser()
        {
            if (_firstParticipant.RoundsWon < MaxRounds)
                return _firstParticipant;

            if (_secondParticipant.RoundsWon < MaxRounds)
                return _secondParticipant;

            throw new ArgumentNullException($"no loser found");
        }
    }
}
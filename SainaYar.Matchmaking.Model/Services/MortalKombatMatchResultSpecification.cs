using System;
using SainaYar.Matchmaking.Core.BaseModels;
using SainaYar.Matchmaking.Core.Interfaces;
using SainaYar.Matchmaking.Core.Model;

namespace SainaYar.Matchmaking.Core.Services
{
    public class MortalKombatPlayerMatchResultSpecification : IMatchResultSpecification<Player> 
    {
        public readonly int MaxRounds = 3;

        private readonly PlayerSpecs _firstParticipant;
        private readonly PlayerSpecs _secondParticipant;

        public MortalKombatPlayerMatchResultSpecification(PlayerSpecs firstPlayerSpecs, PlayerSpecs secondPlayerSpecs)
        {
            _firstParticipant = firstPlayerSpecs;
            _secondParticipant = secondPlayerSpecs;
        }

        public MatchResult<Player> GetResult(Guid matchId, Guid gameId)
        {
            var winner = GetWinner();
            var loser = GetLoser();


            var matchResult = new PlayerMatchResult(Guid.NewGuid(), matchId, gameId);

            SetWinner(matchId, gameId, winner, loser, matchResult);
            SetLoser(matchId, gameId, loser, winner, matchResult);

            return matchResult;
        }

        private void SetWinner(Guid matchId, Guid gameId, PlayerSpecs winner, PlayerSpecs loser, MatchResult<Player> matchResult)
        {
            var winnerResultScores =
                new PlayerResultScore(
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
        private void SetLoser(Guid matchId, Guid gameId, PlayerSpecs loser, PlayerSpecs winner, MatchResult<Player> matchResult)
        {
            var loserResultScores =
                new PlayerResultScore(
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


        private PlayerSpecs GetWinner()
        {
            if (_firstParticipant.RoundsWon == MaxRounds)
                return _firstParticipant;

            if (_secondParticipant.RoundsWon == MaxRounds)
                return _secondParticipant;

            throw new ArgumentNullException($"no winner found");
        }
        private PlayerSpecs GetLoser()
        {
            if (_firstParticipant.RoundsWon < MaxRounds)
                return _firstParticipant;

            if (_secondParticipant.RoundsWon < MaxRounds)
                return _secondParticipant;

            throw new ArgumentNullException($"no loser found");
        }
    }
}
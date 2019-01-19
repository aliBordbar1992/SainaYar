using System;
using SainaYar.Matchmaking.Core.Interfaces;

namespace SainaYar.Matchmaking.Core.Model
{
    public class MatchResult<T>
    {
        public MatchResult(Guid id, Guid gameId, Guid matchId, IWinnerSpecification gameWinSpecification)
        {
            Id = id;
            GameId = gameId;
            MatchId = matchId;
            GameWinSpecification = gameWinSpecification;
        }

        public Guid Id { get; private set; }
        public Guid GameId { get; private set; }
        public Guid MatchId { get; private set; }
        public T Winner { get; private set; }
        public T Loser { get; private set; }
        public ResultScore WinnerScore { get; private set; }
        public ResultScore LoserScore { get; private set; }
        public IWinnerSpecification GameWinSpecification { get; private set; }
        
        public void SetWinner(T winner)
        {
            Winner = winner;
            WinnerScore = GetScores();
        }

        public void SetLoser(T loser)
        {
            Loser = loser;
            LoserScore = GetScores();
        }

        private ResultScore GetScores()
        {
            int roundsWon = GameWinSpecification.RoundsWin;
            int roundsLost = GameWinSpecification.RoundsLost;
            double pointsTaken = GameWinSpecification.Calculator.CalculatePointsTaken();
            double pointLost = GameWinSpecification.Calculator.CalculatePointsLost();

            return new ResultScore(Guid.NewGuid(), Id, GameId, roundsWon, roundsLost, pointsTaken, pointLost);
        }

    }
}

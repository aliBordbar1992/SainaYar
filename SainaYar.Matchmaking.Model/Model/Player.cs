using System;
using SainaYar.Matchmaking.Core.Interfaces;

namespace SainaYar.Matchmaking.Core.Model
{
    public class Player
    {
        public Guid Id { get; }
        public string Name { get; set; }
        public string 

        public Player(Guid id)
        {
            this.Id = id;
        }
        private Player() { }

        public void Won(MatchResult<Player> matchResult, IWinnerSpecification gameWinSpecification)
        {
            int roundsWon = gameWinSpecification.RoundsWin;
            int roundsLost = gameWinSpecification.RoundsLost;
            double pointsTaken = gameWinSpecification.Calculator.CalculatePointsTaken();
            double pointLost = gameWinSpecification.Calculator.CalculatePointsLost();
            ResultScore scores = new ResultScore(Guid.NewGuid(), Id, roundsWon, roundsLost, pointsTaken, pointLost);
            matchResult.SetWinner(this, scores);
        }

        public void Lost(MatchResult<Player> matchResult, IWinnerSpecification gameWinSpecification)
        {
            int roundsWon = gameWinSpecification.RoundsWin;
            int roundsLost = gameWinSpecification.RoundsLost;
            double pointsTaken = gameWinSpecification.Calculator.CalculatePointsTaken();
            double pointLost = gameWinSpecification.Calculator.CalculatePointsLost();

            ResultScore scores = new ResultScore(Guid.NewGuid(), Id, roundsWon, roundsLost, pointsTaken, pointLost);
            matchResult.SetLoser(this, scores);
        }

        public double TotalScoreIn(Guid gameId)
        {
            throw new NotImplementedException();
        }
    }
}

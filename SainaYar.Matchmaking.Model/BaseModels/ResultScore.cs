using System;
using SainaYar.Matchmaking.Core.Interfaces;

namespace SainaYar.Matchmaking.Core.BaseModels
{
    public abstract class ResultScore<T>
    {
        public Guid Id { get; private set; }
        public Guid MatchId { get; private set; }
        public Guid GameId { get; private set; }
        public T Participant { get; private set; }

        public double PointsTaken { get; private set; }
        public double PointLost { get; private set; }

        public int RoundsWon { get; private set; }
        public int RoundsLost { get; private set; }

        protected ResultScore(T participant, Guid matchId, Guid gameId, int roundsWon, int roundsLost)
        {
            Id = Guid.NewGuid();
            Participant = participant;
            GameId = gameId;
            MatchId = matchId;
            RoundsWon = roundsWon;
            RoundsLost = roundsLost;
        }

        public void SetPointsTaken(IPointCalculator calculator)
        {
            PointsTaken = calculator.CalculatePointsTaken();
        }
        public void SetPointsLost(IPointCalculator calculator)
        {
            PointLost = calculator.CalculatePointsLost();
        }
    }
}
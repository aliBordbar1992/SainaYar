using SainaYar.Matchmaking.Core.Interfaces;

namespace SainaYar.Matchmaking.Core.Services
{
    public class MortalKombatPointCalculator : IPointCalculator
    {
        #region Rules
        /*
         * #1- each win grants 5 point to winner (alpha)
         * #2- each round win grants 1 point to loser (alpha)
         * #3- alpha = win score
         * #4- beta = rounds won
         * #5- delta = opponent score - your score
         * #6- if delta < 0 => alpha
         * #7- if delta >= 0 => (delta * (8% * beta)) + alpha
         */
        #endregion

        private readonly int _alpha;
        private readonly int _beta;
        private readonly double _delta;

        public MortalKombatPointCalculator(int maxRounds, int roundsWon, double opponentScore, double yourScore)
        {
            _alpha = roundsWon == maxRounds ? 5 : roundsWon; //#1, #2, #3
            _beta = roundsWon; //#4
            _delta = opponentScore - yourScore; //#5
        }

        public double CalculatePointsTaken()
        {
            return _delta < 0 ? _alpha : CalculateWinScore(); //#6, #7
        }
        private double CalculateWinScore()
        {
            //implementing #7
            //(delta * (8% * beta)) + alpha

            return (_delta * (_beta * 0.08)) + _alpha;
        }

        public double CalculatePointsLost()
        {
            return 0;
        }
    }
}
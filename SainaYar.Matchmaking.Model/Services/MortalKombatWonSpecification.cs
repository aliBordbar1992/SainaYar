using SainaYar.Matchmaking.Core.Interfaces;

namespace SainaYar.Matchmaking.Core.Services
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

    public class MortalKombatWinnerSpecification : IWinnerSpecification
    {
        public int RoundsWin { get; }
        public int RoundsLost { get; }
        public IPointCalculator Calculator { get; }

        public MortalKombatWinnerSpecification(int roundsWin, int roundsLost, IPointCalculator calculator)
        {
            RoundsWin = roundsWin;
            RoundsLost = roundsLost;
            Calculator = calculator;
        }
    }

    public class MortalKombatPointCalculator : IPointCalculator
    {
        public readonly int MaxRounds = 3;

        private int alpha;
        private int beta;
        private double delta;
        

        public MortalKombatPointCalculator(int roundsWon, double opponentScore, double yourScore)
        {
            alpha = roundsWon == MaxRounds ? 5 : roundsWon; //#1, #2, #3
            beta = roundsWon; //#4
            delta = opponentScore - yourScore; //#5
        }

        public double CalculatePointsTaken()
        {
            return delta < 0 ? alpha : CalculateWinScore(); //#6, #7
        }

        private double CalculateWinScore()
        {
            //implementing #7
            //(delta * (8% * beta)) + alpha

            return (delta * (beta * 0.08)) + alpha;
        }

        public double CalculatePointsLost()
        {
            return 0;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using SainaYar.Matchmaking.Core.Services;
using Xunit;

namespace SainaYar.Matchmaking.Tests
{
    public class WinSpecificationTests
    {
        [Fact]
        public void MortalKombatWinScoreTest_1()
        {
            int roundsWon = 3;
            int roundsLost = 2;
            double myScore = 10;
            double opponentScore = 20;

            MortalKombatPointCalculator mkCalculator = new MortalKombatPointCalculator(roundsWon, opponentScore, myScore);
            MortalKombatWinnerSpecification mkSpecs = new MortalKombatWinnerSpecification(roundsWon, roundsLost, mkCalculator);

            double pointsTaken = mkSpecs.Calculator.CalculatePointsTaken();

            pointsTaken.Should().Be(7.4);
        }
        [Fact]
        public void MortalKombatWinScoreTest_2()
        {
            int roundsWon = 3;
            int roundsLost = 2;
            double myScore = 20;
            double opponentScore = 10;

            MortalKombatPointCalculator mkCalculator = new MortalKombatPointCalculator(roundsWon, opponentScore, myScore);
            MortalKombatWinnerSpecification mkSpecs = new MortalKombatWinnerSpecification(roundsWon, roundsLost, mkCalculator);

            double pointsTaken = mkSpecs.Calculator.CalculatePointsTaken();

            pointsTaken.Should().Be(5);
        }

        [Fact]
        public void MortalKombatLoseScoreTest_1()
        {
            int roundsWon = 2;
            int roundsLost = 3;
            double myScore = 10;
            double opponentScore = 20;

            MortalKombatPointCalculator mkCalculator = new MortalKombatPointCalculator(roundsWon, opponentScore, myScore);
            MortalKombatWinnerSpecification mkSpecs = new MortalKombatWinnerSpecification(roundsWon, roundsLost, mkCalculator);

            double pointsTaken = mkSpecs.Calculator.CalculatePointsTaken();

            pointsTaken.Should().Be(3.6);
        }
        [Fact]
        public void MortalKombatLoseScoreTest_2()
        {
            int roundsWon = 2;
            int roundsLost = 3;
            double myScore = 20;
            double opponentScore = 10;

            MortalKombatPointCalculator mkCalculator = new MortalKombatPointCalculator(roundsWon, opponentScore, myScore);
            MortalKombatWinnerSpecification mkSpecs = new MortalKombatWinnerSpecification(roundsWon, roundsLost, mkCalculator);

            double pointsTaken = mkSpecs.Calculator.CalculatePointsTaken();

            pointsTaken.Should().Be(2);
        }
    }
}

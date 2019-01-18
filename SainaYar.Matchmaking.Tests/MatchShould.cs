using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using SainaYar.Matchmaking.Core.Model;
using SainaYar.Matchmaking.Core.Services;
using Xunit;

namespace SainaYar.Matchmaking.Tests
{
    public class MatchShould
    {
        [Fact]
        public void HaveA_Winner()
        {
            Player playerA = new Player(Guid.NewGuid()) { Name = "A" };
            Player playerB = new Player(Guid.NewGuid()) { Name = "B" };
            Game g = new Game(Guid.NewGuid(), "Mortal Kombat");
            DateTime tomorrow = DateTime.Now.AddDays(1);
            Match<Player> theMatch = new Match<Player>(Guid.NewGuid(), g.Id, playerA, playerB, g, tomorrow);

            int roundsWon = 3;
            int roundsLost = 2;
            MortalKombatPointCalculator mkCalculator = new MortalKombatPointCalculator(roundsWon, playerB.TotalScoreIn(g.Id), playerA.TotalScoreIn(g.Id));
            MortalKombatWinnerSpecification mkSpecs = new MortalKombatWinnerSpecification(roundsWon, roundsLost, mkCalculator);

            var result = theMatch.Result();

            playerA.Won(result, mkSpecs);
            playerB.Lost(result, mkSpecs);

            result.Winner.Should().Be(playerA);
            result.Loser.Should().Be(playerB);
        }
        [Fact]
        public void HaveA_Loser()
        {
            Player playerA = new Player(Guid.NewGuid()) { Name = "A" };
            Player playerB = new Player(Guid.NewGuid()) { Name = "B" };
            Game g = new Game(Guid.NewGuid(), "Mortal Kombat");
            DateTime tomorrow = DateTime.Now.AddDays(1);
            Match<Player> theMatch = new Match<Player>(Guid.NewGuid(), g.Id, playerA, playerB, g, tomorrow);

            int roundsWon = 3;
            int roundsLost = 2;
            MortalKombatPointCalculator mkCalculator = new MortalKombatPointCalculator(roundsWon, playerB.TotalScoreIn(g.Id), playerA.TotalScoreIn(g.Id));
            MortalKombatWinnerSpecification mkSpecs = new MortalKombatWinnerSpecification(roundsWon, roundsLost, mkCalculator);

            var result = theMatch.Result();

            
        }
    }
}

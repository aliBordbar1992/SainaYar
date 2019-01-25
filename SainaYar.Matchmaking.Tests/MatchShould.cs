using System;
using System.Collections.Generic;
using FluentAssertions;
using Moq;
using SainaYar.Matchmaking.Core.Interfaces;
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
            Game game = new Game(Guid.NewGuid(), "Mortal Kombat");
            DateTime tomorrow = DateTime.Now.AddDays(1);
            Core.BaseModels.Match<Player> theMatch = new PlayerMatch(Guid.NewGuid(), game.Id, playerA, playerB, game, tomorrow);

            var mockA = new Mock<IGameResultRepository>();
            mockA.Setup(x => x.GameScores(playerA.Id, game.Id)).Returns(ResultScoreMockPlayerA(playerA, game.Id, theMatch.Id));
            var mockB = new Mock<IGameResultRepository>();
            mockB.Setup(x => x.GameScores(playerA.Id, game.Id)).Returns(ResultScoreMockPlayerB(playerB, game.Id, theMatch.Id));

            IMatchResultSpecification<Player> mkSpecs = new MortalKombatPlayerMatchResultSpecification(
                playerA.Specs(mockA.Object, game.Id, 3),
                playerB.Specs(mockB.Object, game.Id, 2));

            var result = theMatch.Result(mkSpecs);

            result.Winner.Participant.Should().Be(playerA);
            result.Loser.Participant.Should().Be(playerB);
        }

        private List<PlayerResultScore> ResultScoreMockPlayerA(Player player, Guid gameId, Guid matchId)
        {
            var score1 = new PlayerResultScore(player, matchId, gameId, 3, 2);
            var clc = new MortalKombatPointCalculator(3, 3, 0, 0);
            score1.SetPointsTaken(clc);
            score1.SetPointsLost(clc);

            var score2 = new PlayerResultScore(player, matchId, gameId, 1, 3);
            clc = new MortalKombatPointCalculator(3, 1, 0, 5);
            score2.SetPointsTaken(clc);
            score2.SetPointsLost(clc);

            var score3 = new PlayerResultScore(player, matchId, gameId, 3, 1);
            clc = new MortalKombatPointCalculator(3, 3, 6.2, 6);
            score3.SetPointsTaken(clc);
            score3.SetPointsLost(clc);

            List<PlayerResultScore> scores = new List<PlayerResultScore> {score1, score2, score3};
            return scores;
        }
        private List<PlayerResultScore> ResultScoreMockPlayerB(Player player, Guid gameId, Guid matchId)
        {
            var score1 = new PlayerResultScore(player, matchId, gameId, 2, 3);
            var clc = new MortalKombatPointCalculator(3, 2, 0, 0);
            score1.SetPointsTaken(clc);
            score1.SetPointsLost(clc);

            var score2 = new PlayerResultScore(player, matchId, gameId, 3, 1);
            clc = new MortalKombatPointCalculator(3, 3, 5, 0);
            score2.SetPointsTaken(clc);
            score2.SetPointsLost(clc);

            var score3 = new PlayerResultScore(player, matchId, gameId, 1, 3);
            clc = new MortalKombatPointCalculator(3, 1, 6, 6.2);
            score2.SetPointsTaken(clc);
            score2.SetPointsLost(clc);

            List<PlayerResultScore> scores = new List<PlayerResultScore> {score1, score2, score3};
            return scores;
        }
    }
}

﻿using System;
using FluentAssertions;
using SainaYar.Matchmaking.Core.BaseModels;
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
            Game mortalKombatGame = new Game(Guid.NewGuid(), "Mortal Kombat");
            DateTime tomorrow = DateTime.Now.AddDays(1);
            Match<Player> theMatch = new PlayerMatch(Guid.NewGuid(), mortalKombatGame.Id, playerA, playerB, mortalKombatGame, tomorrow);

            IMatchResultSpecification<Player> mkSpecs = new MortalKombatPlayerMatchResultSpecification(
                playerA.Specs(mortalKombatGame.Id, 3),
                playerB.Specs(mortalKombatGame.Id, 2));

            var result = theMatch.Result(mkSpecs);

            result.Winner.Should().Be(playerA);
            result.Loser.Should().Be(playerB);
        }
    }
}

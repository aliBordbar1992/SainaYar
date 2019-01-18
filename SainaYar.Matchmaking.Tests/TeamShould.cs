using System;
using System.Linq;
using FluentAssertions;
using SainaYar.Matchmaking.Core;
using SainaYar.Matchmaking.Core.Model;
using Xunit;

namespace SainaYar.Matchmaking.Tests
{
    public class TeamShould
    {
        [Fact]
        public void BeAbleToAddPlayers()
        {
            Team aTeam = new Team(Guid.NewGuid());
            Player aPlayer = new Player(Guid.NewGuid());
            aTeam.AddPlayer(aPlayer);

            aTeam.Players.Count().Should().Be(1);
        }
        [Fact]
        public void NotBeAbleToAddDuplicatePlayers()
        {
            Team aTeam = new Team(Guid.NewGuid());
            Player aPlayer = new Player(Guid.NewGuid());
            aTeam.AddPlayer(aPlayer);
            aTeam.AddPlayer(aPlayer);

            aTeam.Players.Count().Should().Be(1);
        }
    }
}

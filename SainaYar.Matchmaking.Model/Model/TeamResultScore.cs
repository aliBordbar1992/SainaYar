using System;
using SainaYar.Matchmaking.Core.BaseModels;

namespace SainaYar.Matchmaking.Core.Model
{
    public class TeamResultScore : ResultScore<Team>
    {
        public TeamResultScore(Team participant, Guid matchId, Guid gameId, int roundsWon, int roundsLost) 
            : base(participant, matchId, gameId, roundsWon, roundsLost)
        {
        }
    }
}
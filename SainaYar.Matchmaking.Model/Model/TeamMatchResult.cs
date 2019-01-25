using System;
using System.Collections.Generic;
using System.Text;
using SainaYar.Matchmaking.Core.BaseModels;

namespace SainaYar.Matchmaking.Core.Model
{
    public class TeamMatchResult : MatchResult<Team>
    {
        public TeamMatchResult(Guid id, Guid matchId, Guid gameId) : base(id, matchId, gameId)
        {
        }
    }
}

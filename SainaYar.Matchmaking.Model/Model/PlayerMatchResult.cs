using System;
using System.Collections.Generic;
using System.Text;
using SainaYar.Matchmaking.Core.BaseModels;

namespace SainaYar.Matchmaking.Core.Model
{
    public class PlayerMatchResult : MatchResult<Player>
    {
        public PlayerMatchResult(Guid id, Guid matchId, Guid gameId) : base(id, matchId, gameId)
        {
        }
    }
}

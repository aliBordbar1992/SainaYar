using System;
using System.Collections.Generic;
using System.Text;
using SainaYar.Matchmaking.Core.BaseModels;

namespace SainaYar.Matchmaking.Core.Model
{
    public class TeamMatch : Match<Team>
    {
        public TeamMatch(Guid id, Guid gameId, Team host, Team guest, Game game, DateTime schedule) : base(id, gameId, host, guest, game, schedule)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using SainaYar.Matchmaking.Core.BaseModels;

namespace SainaYar.Matchmaking.Core.Model
{
    public class PlayerMatch : Match<Player>
    {
        public PlayerMatch(Guid id, Guid gameId, Player host, Player guest, Game game, DateTime schedule) : base(id, gameId, host, guest, game, schedule)
        {
        }
    }
}

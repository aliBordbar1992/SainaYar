using System;
using System.Collections.Generic;
using SainaYar.Matchmaking.Core.Model;

namespace SainaYar.Matchmaking.Core.Interfaces
{
    public interface IGameResultRepository
    {
        IEnumerable<PlayerResultScore> GameScores(Guid playerId, Guid gameId);
    }
}
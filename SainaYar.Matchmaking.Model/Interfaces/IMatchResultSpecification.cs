using System;
using SainaYar.Matchmaking.Core.BaseModels;
using SainaYar.Matchmaking.Core.Model;

namespace SainaYar.Matchmaking.Core.Interfaces
{
    public interface IMatchResultSpecification<T>
    {
        MatchResult<T> GetResult(Guid matchId, Guid gameId);
    }
}
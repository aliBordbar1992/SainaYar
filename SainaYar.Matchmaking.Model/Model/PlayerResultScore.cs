using System;
using SainaYar.Matchmaking.Core.BaseModels;

namespace SainaYar.Matchmaking.Core.Model
{
    public class PlayerResultScore : ResultScore<Player>
    {
        public PlayerResultScore(Player participant, Guid matchId, Guid gameId, int roundsWon, int roundsLost) 
            : base(participant, matchId, gameId, roundsWon, roundsLost)
        {
        }
    }
}
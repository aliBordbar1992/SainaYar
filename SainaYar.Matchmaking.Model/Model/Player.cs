using System;
using SainaYar.Matchmaking.Core.BaseModels;

namespace SainaYar.Matchmaking.Core.Model
{
    public class Player
    {
        public Guid Id { get; }
        public string Name { get; set; }

        public Player(Guid id)
        {
            this.Id = id;
        }
        private Player() { }

        public double TotalScoreIn(Guid gameId)
        {
            throw new NotImplementedException();
        }

        public PlayerSpecs Specs(Guid gameId, int roundsWon)
        {
            return new PlayerSpecs(this, roundsWon, TotalScoreIn(gameId));
        }
    }
}

using System;
using SainaYar.Matchmaking.Core.DTO;
using SainaYar.Matchmaking.Core.Interfaces;

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

        public ParticipantSpecs<Player> Specs(Guid gameId, int roundsWon)
        {
            return new ParticipantSpecs<Player>(this, roundsWon, TotalScoreIn(gameId));
        }
    }
}

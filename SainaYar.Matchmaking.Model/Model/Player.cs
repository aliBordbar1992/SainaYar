using System;
using SainaYar.Matchmaking.Core.BaseModels;
using SainaYar.Matchmaking.Core.Interfaces;
using SainaYar.Matchmaking.Core.Services;

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

        public double TotalScoreIn(IGameResultRepository gameResult, Guid gameId)
        {
            GameScoreProvider gsp = new GameScoreProvider(gameResult);
            return gsp.PlayerScoresInGame(Id, gameId);
        }

        public PlayerSpecs Specs(IGameResultRepository gameResult, Guid gameId, int roundsWon)
        {
            return new PlayerSpecs(this, roundsWon, TotalScoreIn(gameResult, gameId));
        }
    }
}

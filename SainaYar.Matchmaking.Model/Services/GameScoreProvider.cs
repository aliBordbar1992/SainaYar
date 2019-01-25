using System;
using System.Collections.Generic;
using System.Linq;
using SainaYar.Matchmaking.Core.Interfaces;
using SainaYar.Matchmaking.Core.Model;

namespace SainaYar.Matchmaking.Core.Services
{
    public class GameScoreProvider
    {
        private IGameResultRepository _gameResult;
        public GameScoreProvider(IGameResultRepository gameResult)
        {
            _gameResult = gameResult;
        }
        public double PlayerScoresInGame(Guid playerId, Guid gameId)
        {
            var playerScores = _gameResult.GameScores(playerId, gameId);
            return playerScores.Sum(x => x.PointsTaken);
        }
    }
}
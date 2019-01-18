using System;
using SainaYar.Matchmaking.Core.Interfaces;

namespace SainaYar.Matchmaking.Core.Model
{
    public class MatchResult<T>
    {
        public MatchResult(Guid id, Guid gameId, Guid matchId)
        {
            Id = id;
            GameId = gameId;
            MatchId = matchId;
        }

        public Guid Id { get; private set; }
        public Guid GameId { get; private set; }
        public Guid MatchId { get; private set; }
        public T Winner { get; private set; }
        public T Loser { get; private set; }
        public ResultScore WinnerScore { get; private set; }
        public ResultScore LoserScore { get; private set; }
        
        public void SetWinner(T winner, ResultScore winnerScore)
        {
            Winner = winner;
            WinnerScore = winnerScore;
        }

        public void SetLoser(T loser, ResultScore loserScore)
        {
            Loser = loser;
            LoserScore = loserScore;
        }
    }
}

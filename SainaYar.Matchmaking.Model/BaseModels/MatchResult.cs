using System;

namespace SainaYar.Matchmaking.Core.BaseModels
{
    public abstract class MatchResult<T>
    {
        public Guid Id { get; private set; }
        public Guid MatchId { get; private set; }
        public Guid GameId { get; private set; }
        public ResultScore<T> Winner { get; private set; }
        public ResultScore<T> Loser { get; private set; }

        protected MatchResult(Guid id, Guid matchId, Guid gameId)
        {
            Id = id;
            MatchId = matchId;
            GameId = gameId;
        }

        public void SetWinner(ResultScore<T> winner)
        {
            Winner = winner;
        }

        public void SetLoser(ResultScore<T> loser)
        {
            Loser = loser;
        }
    }
}

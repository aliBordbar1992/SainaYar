﻿using System;
using SainaYar.Matchmaking.Core.Interfaces;

namespace SainaYar.Matchmaking.Core.Model
{
    public class Match<T>
    {
        public Guid Id { get; }
        public Guid GameId { get; }
        public T Host { get; }
        public T Guest { get; }
        public DateTime MatchDate { get; set; }

        private Match() { }
        public Match(Guid id,Guid gameId, T host, T guest, Game game, DateTime schedule)
        {
            Id = id;
            Host = host;
            Guest = guest;
            GameId = gameId;
            MatchDate = schedule;
        }

        public MatchResult<T> Result(IMatchResultSpecification<T> gameWinSpecification)
        {
            return gameWinSpecification.GetResult(Id, GameId);
        }
    }
}

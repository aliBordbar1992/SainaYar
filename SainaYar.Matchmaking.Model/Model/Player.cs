using System;
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

        //public void Won(MatchResult<Player> matchResult, IWinnerSpecification gameWinSpecification)
        //{
        //    _matchResult = matchResult;
        //    _gameWinSpecification = gameWinSpecification;

        //    matchResult.SetWinner(this, GetScores());
        //}

        //public void Lost(MatchResult<Player> matchResult, IWinnerSpecification gameWinSpecification)
        //{
        //    _matchResult = matchResult;
        //    _gameWinSpecification = gameWinSpecification;

        //    matchResult.SetLoser(this, GetScores());
        //}

        
        public double TotalScoreIn(Guid gameId)
        {
            throw new NotImplementedException();
        }
    }
}

using System;

namespace SainaYar.Matchmaking.Core.Model
{
    public class Game
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Game(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
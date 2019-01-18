using System;
using System.Collections.Generic;
using System.Linq;

namespace SainaYar.Matchmaking.Core.Model
{
    public class Team
    {
        public Guid Id { get; }
        public string Name { get; set; }

        public virtual ICollection<Player> Players { get; private set; }

        private Team() {}
        public Team(Guid id)
        {
            Id = id;
            Players = new List<Player>();
        }

        public void AddPlayer(Player player)
        {
            if (Players.All(x => x.Id != player.Id))
                Players.Add(player);
        }
    }
}

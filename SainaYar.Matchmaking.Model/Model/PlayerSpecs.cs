using SainaYar.Matchmaking.Core.BaseModels;

namespace SainaYar.Matchmaking.Core.Model
{
    public class PlayerSpecs : ParticipantSpecs<Player>
    {
        public PlayerSpecs(Player participant, int roundsWon, double previousScore) : base(participant, roundsWon, previousScore)
        {
        }
    }
}
using SainaYar.Matchmaking.Core.BaseModels;

namespace SainaYar.Matchmaking.Core.Model
{
    public class TeamSpecs : ParticipantSpecs<Team>
    {
        public TeamSpecs(Team participant, int roundsWon, double previousScore) : base(participant, roundsWon, previousScore)
        {
        }
    }
}
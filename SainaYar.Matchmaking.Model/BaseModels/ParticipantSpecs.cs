namespace SainaYar.Matchmaking.Core.BaseModels
{
    public abstract class ParticipantSpecs<T>
    {
        public T Participant { get; set; }
        public int RoundsWon { get; set; }
        public double PreviousScore { get; set; }

        protected ParticipantSpecs(T participant, int roundsWon, double previousScore)
        {
            Participant = participant;
            RoundsWon = roundsWon;
            PreviousScore = previousScore;
        }
    }
}

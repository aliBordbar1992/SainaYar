namespace SainaYar.Matchmaking.Core.Interfaces
{
    public interface IPointCalculator
    {
        //ResultScore<T> CalculateResultScore(Guid gameId, Guid participantId);
        double CalculatePointsTaken();
        double CalculatePointsLost();
    }
}
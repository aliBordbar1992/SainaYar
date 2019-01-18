namespace SainaYar.Matchmaking.Core.Interfaces
{
    public interface IWinnerSpecification
    {
        int RoundsWin { get; }
        int RoundsLost { get; }

        IPointCalculator Calculator { get; }
    }
}
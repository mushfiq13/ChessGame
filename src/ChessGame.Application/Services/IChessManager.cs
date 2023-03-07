namespace ChessGame.Application;

public interface IChessManager : IDisposable
{
    bool IsGameRunning { get; }

    void Processor();
}

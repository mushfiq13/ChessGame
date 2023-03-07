namespace ChessGame.Application;

public interface IChessGenerator : IDisposable
{
    bool IsGameRunning { get; }

    void Processor();
}

namespace ChessGame.Application;

public interface IChessManager
{
    bool IsGameRunning { get; }

    void Processor();
}

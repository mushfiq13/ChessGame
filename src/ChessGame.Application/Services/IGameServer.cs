using ChessGame.Domain;

namespace ChessGame.Application;

internal interface IGameServer : IDisposable
{
    IList<IChessCore> BlackCaptured { get; }
    IList<IChessCore> WhiteCaptured { get; }
    bool WhiteInTurn { get; }
    IChessCore? Winner { get; }

    void Run();
    void Clear();
}
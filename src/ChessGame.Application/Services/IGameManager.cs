using ChessGame.Domain;

namespace ChessGame.Application;

public interface IGameManager : IGameCoreManager, IDisposable
{
    IList<IChessCore> WhiteCaptured { get; }
    IList<IChessCore> BlackCaptured { get; }
}

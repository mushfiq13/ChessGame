using ChessGame.Domain;

namespace ChessGame.Application;

public interface IGameManager : IDisposable
{
    IList<IChess> WhiteChessSet { get; }
    IList<IChess> BlackChessSet { get; }

    void Play();
}
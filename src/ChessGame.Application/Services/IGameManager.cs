using ChessGame.Domain;

namespace ChessGame.Application;

public interface IGameManager
{
    IList<IChess> WhiteChessSet { get; }
    IList<IChess> BlackChessSet { get; }

    void Play();
}
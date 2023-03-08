using ChessGame.Domain;

namespace ChessGame.Application;

public interface IGameManager : IDisposable
{
    ChessColor? CurrentPlayer { get; }
    ChessColor? Winner { get; }

    void Play();
    void Replay();
    bool Over();
}

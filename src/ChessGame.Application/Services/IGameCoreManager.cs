using ChessGame.Domain;

namespace ChessGame.Application;

public interface IGameCoreManager
{
    bool WhiteInTurn { get; }
    ChessColor? Winner { get; }
    bool GameOver { get; }

    void Play();
}

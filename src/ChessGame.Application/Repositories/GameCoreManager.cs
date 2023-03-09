using ChessGame.Domain;

namespace ChessGame.Application;

public abstract class GameCoreManager : IGameCoreManager
{
    ChessColor? _winner = null;

    public bool WhiteInTurn { get; protected set; } = true;
    public bool GameOver => Winner is not null;
    public ChessColor? Winner
    {
        get
        {
            return _winner;
        }
        set
        {
            if (value?.GetType() == typeof(ChessColor) && _winner is null)
                _winner = value;
        }
    }

    public abstract void Play();
}

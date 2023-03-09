using ChessGame.Application;

namespace ChessGame.API;

internal static class Factory
{
    public static IGameManager CreateGameManager()
        => new GameManager();
}

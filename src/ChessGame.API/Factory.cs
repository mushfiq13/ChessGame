using ChessGame.Application;

namespace ChessGame.API;

internal static class Factory
{
    public static IChessApplication CreateChessApplication()
        => new ChessApplication();
}

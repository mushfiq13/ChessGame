using ChessGame.Application;

namespace ChessGame.API;

internal static class Factory
{
    public static IChessApplicationServiceProvider CreateChessApplication()
        => new ChessApplicationServiceProvider();
}

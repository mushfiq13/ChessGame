using ChessGame.Application;

namespace ChessGame.API;

internal static class Factory
{
    public static IApplicationServiceProvider CreateChessApplication()
        => new ApplicationServiceProvider();
}

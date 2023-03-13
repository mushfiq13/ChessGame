using ChessGame.Domain;

namespace ChessGame.Application;

internal interface ICaptureHandler
{
    (int rank, int file) Handle(Predicate<ChessColor?>? customValidator,
        Predicate<(int, int)>? moveChecker);
}
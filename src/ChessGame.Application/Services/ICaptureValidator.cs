using ChessGame.Domain;

namespace ChessGame.Application;

internal interface ICaptureValidator
{
    bool Validate(int rank, int file, Predicate<ChessColor?>? validator);
}
using ChessGame.Domain;

namespace ChessGame.Application;

internal class CaptureValidator : ICaptureValidator
{
    public bool Validate(int? rank, int? file, Predicate<ChessColor?>? validator)
    {
        try
        {
            if (Inbound(rank, file) is false)
                throw new InvalidDataException();

            if (validator is not null
                && validator(Singleton.ChessBoard[(int)rank, (int)file]?.Color) is false)
                throw new InvalidDataException();

            return true;
        }
        catch
        {
            Singleton.ConsoleMessages.InvalidDataCapture();
        }

        return false;
    }

    private bool Inbound(int? rank, int? file)
        => rank >= 0 && file >= 0
            && rank < 8 && file < 8;
}

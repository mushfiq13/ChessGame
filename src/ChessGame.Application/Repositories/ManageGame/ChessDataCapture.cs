using ChessGame.Domain;

namespace ChessGame.Application;

internal class ChessDataCapture : IChessDataCapture
{
    public (IChess source, (int rank, int file) target)? Capture(ChessColor sourceColor)
    {
        Singleton.ConsoleMessages.WriteMessage("\nPlease choose a moveable chess. (white-space must use as a separator)");
        Singleton.ConsoleMessages.WriteMessage("Enter rank and file ->");
        var sourceLocation = Capture(sourceColor, SourceDataValidator);

        Singleton.ConsoleMessages.WriteMessage("\nPlease choose a target tile. (white-space must use as a separator)");
        Singleton.ConsoleMessages.WriteMessage("Enter rank and file ->");
        var targetLocation = Capture(sourceColor, TargetDataValidator);

        var source = Singleton.BoardManager.Tiles[sourceLocation.Item1, sourceLocation.Item2];

        if (source.IsMoveable(Singleton.BoardManager.Tiles,
            targetLocation.rank, targetLocation.file))
        {
            return (source, (targetLocation.rank, targetLocation.file));
        }

        Singleton.ConsoleMessages.InvalidDataCapture();
        Singleton.ConsoleMessages.WriteMessage
            ("Your source chess can not move. It's invalid choice!");

        return null;
    }

    private (int rank, int file) Capture(ChessColor color, Func<IChess, ChessColor, bool> validator)
    {
        var input = Singleton.ConsoleInput.CaptureTile() as string;
        (int rank, int file) = GetLocation(input);

        if (Inbound(rank, file)
           && validator(Singleton.BoardManager.Tiles[rank, file], color))
            return (rank, file);

        Singleton.ConsoleMessages.InvalidDataCapture();

        return Capture(color, validator);
    }

    private bool SourceDataValidator(IChess item, ChessColor expectedColor)
        => item?.Color == expectedColor;

    private bool TargetDataValidator(IChess item, ChessColor restrictedColor)
        => item?.Color != restrictedColor;

    private (int, int) GetLocation(string input)
    {
        var parts = input.Where(c => c != ' ').ToArray();

        if (parts.Length == 2 && char.IsDigit(parts[0]) && char.IsDigit(parts[1]))
            return (parts[0] - '0', parts[1] - '0');

        return (-1, -1);
    }

    private bool Inbound(int rank, int file)
            => rank >= 0 && file >= 0
                && rank < 8 && file < 8;
}

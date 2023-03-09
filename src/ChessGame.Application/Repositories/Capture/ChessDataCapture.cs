using ChessGame.Domain;

namespace ChessGame.Application;

internal class ChessDataCapture : IChessDataCapture
{
    IUICommands _uICommands = Factory.CreateConsoleUICommands();

    public (IChess source, (int rank, int file) target) Capture(
        IChess[,] tiles,
        ChessColor sourceColor)
    {
        _uICommands.WriteMessage("\nPlease choose a moveable chess. (white-space must use as a separator)");
        _uICommands.WriteMessage("Enter rank and file ->");
        // Capture Source Tile
        var sourceLocation = Capture(tiles, sourceColor,
            (IChess chess) => chess?.Color == sourceColor);

        _uICommands.WriteMessage("\nPlease choose a target tile. (white-space must use as a separator)");
        _uICommands.WriteMessage("Enter rank and file ->");
        // Capture Target Tile
        var targetLocation = Capture(tiles, sourceColor,
            (IChess chess) => chess?.Color != sourceColor);

        return (tiles[sourceLocation.Item1, sourceLocation.Item2], targetLocation);
    }

    private (int rank, int file) Capture(IChess[,] tiles, ChessColor sourceColor, Predicate<IChess> validator)
    {
        (int rank, int file) = _uICommands.CaptureChess();

        if (validator(tiles[rank, file]))
            return (rank, file);

        _uICommands.InvalidDataCapture();

        return Capture(tiles, sourceColor, validator);
    }
}

using ChessGame.Domain;

namespace ChessGame.Application;

internal class CaptureProcessor : ICaptureProcessor
{
    ICapturer _capturer = Factory.CreateCapturer();
    ICaptureValidator _validator = Factory.CreateCaptureValidator();

    public (IChess sourceChess, (int rank, int file)? targetTile) Run(ChessColor movingColor)
    {
        Singleton.ConsoleMessages.WriteMessage("\n\nPlease choose a moveable chess. Format: [1 2]");
        var sourceTile = HandleSourceTile(movingColor);

        if (sourceTile is null) return (null, null);

        var sourceChess = Singleton.ChessBoard[(int)sourceTile?.rank, (int)sourceTile?.file];

        Singleton.ConsoleMessages.WriteMessage("\n\nPlease choose a target chess. Format: [1 2]");
        var targetTile = HandleTargetTile(sourceChess, movingColor);

        return (sourceChess, targetTile);
    }

    private (int rank, int file)? HandleSourceTile(ChessColor requiredColor)
    {
        bool SourceTileValidator(ChessColor? capturedColor)
            => capturedColor == requiredColor;

        return GetTile(SourceTileValidator);
    }

    private (int rank, int file)? HandleTargetTile(IChess sourceChess, ChessColor restrictedColor)
    {
        bool TargetTileValidator(ChessColor? capturedColor)
            => capturedColor != restrictedColor;

        var targetTile = GetTile(TargetTileValidator);
        var rank = (int)targetTile?.rank;
        var file = (int)targetTile?.file;

        if (targetTile is not null && sourceChess.IsMoveable(Singleton.ChessBoard.Tiles, rank, file))
            return targetTile;

        Singleton.ConsoleMessages.WriteMessage("Invalid move! You can not move to that target." +
             "Do you want to continue playing? (y/n)");

        if (Singleton.ConsoleInput.ReadText().ToLower() == "y")
            return HandleTargetTile(sourceChess, restrictedColor);

        return null;
    }

    private (int rank, int file)? GetTile(Predicate<ChessColor?>? validatorChecker, int capturingLimit = 5)
    {
        for (var i = 0; i < capturingLimit; ++i)
        {
            (int rank, int file)? tile = _capturer.Capture();

            if (tile != null
                && _validator.Validate(tile?.rank, tile?.file, validatorChecker))
            {
                return tile;
            }

            Singleton.ConsoleMessages.WriteMessage("Try Again!");
        }

        Singleton.ConsoleMessages.WriteMessage("You tried a lot of time. " +
                "Do you want to continue playing? (y/n)");

        if (Singleton.ConsoleInput.ReadText().ToLower() == "y")
            return null;

        Singleton.ConsoleMessages.WriteMessage("Give a new try");

        return GetTile(validatorChecker);
    }
}

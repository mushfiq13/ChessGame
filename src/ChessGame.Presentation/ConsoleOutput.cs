namespace ChessGame.Presentation;

public class ConsoleOutput : IConsoleOutput
{
    private int _tileWidth { get; } = 5;

    public void DisplayWelcome()
    {
        ConsoleIOMessager.WelcomeMessage();
    }

    public void ShowBoard(in object[,] tiles)
    {
        var totalRanks = tiles.GetLength(0);
        var totalFiles = totalRanks;

        for (var rank = 0; rank < totalRanks; ++rank)
        {
            Console.Write($"{rank}  ");
            for (var file = 0; file < totalFiles; file++)
            {
                var consoleBackgroundColor = ((rank % 2 != 0 && file % 2 == 0)
                    || (rank % 2 == 0 && file % 2 != 0))
                    ? ConsoleColor.Red : ConsoleColor.Green;

                SetTileColor(tiles[rank, file], consoleBackgroundColor);

                var output = FormatUnicode(tiles[rank, file]?.GetType().GetProperty("Unicode").GetValue(tiles[rank, file]), _tileWidth);
                DisplayPieceOrNull(output);
            }
            Console.Write("\r\n");
        }

        Console.WriteLine();
    }

    private void SetTileColor(object piece, ConsoleColor consoleBackgroundColor = ConsoleColor.Green)
    {
        Console.BackgroundColor = consoleBackgroundColor;
        Console.ForegroundColor = piece?.GetType().GetProperty("Color").GetValue(piece).ToString() == "White"
            ? ConsoleColor.White : ConsoleColor.Black;
    }

    private string FormatUnicode(object unicode, int tileWidth)
        => $"{new string(' ', tileWidth / 2)}{unicode ?? "."}{new string(' ', tileWidth / 2)}";

    private void DisplayPieceOrNull(object obj)
    {
        Console.Write(obj);

        Console.ResetColor();

        // it has been written to wait for resetting the color.
        Thread.Sleep(0);
    }
}

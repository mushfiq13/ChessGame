namespace ChessGame.ConsoleUI;

internal partial class ConsoleOutput
{
    public IConsoleOutput DrawBoard(in object[,] tiles)
    {
        var totalRanks = tiles.GetLength(0);
        var totalFiles = tiles.GetLength(1);

        for (var rank = totalRanks - 1; rank >= 0; --rank)
        {
            Console.Write(FormatTile(rank.ToString()));

            var consoleBackgroundColor = rank % 2 == 0 ? ConsoleColor.Green : ConsoleColor.Red;
            for (var file = 0; file < totalFiles; file++)
            {
                Colorize(tiles[rank, file], consoleBackgroundColor);

                var output = FormatTile(tiles[rank, file]?.GetType()
                    .GetProperty("Unicode")
                    .GetValue(tiles[rank, file]));

                Console.Write(output);
                Console.ResetColor();

                consoleBackgroundColor = consoleBackgroundColor == ConsoleColor.Green
                   ? ConsoleColor.Red : ConsoleColor.Green;
            }

            Console.WriteLine("\r");
        }

        Console.Write(FormatTile());
        for (var file = 0; file < totalFiles; file++)
        {
            Console.Write(FormatTile(file.ToString()));
        }

        Console.WriteLine("\r");

        return this;
    }

    private string FormatTile(object? obj = null)
    {
        var padding = new string(' ', 3);

        return $"{padding}{obj ?? " "}{padding}";
    }
}

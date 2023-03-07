namespace ChessGame.ConsoleUI;

public class ConsoleOutput : IConsoleOutput
{
    private int _padding = 3;
    private ConsoleIOMessager _iOMessager = new();

    public void WriteMessage(string text)
    {
        _iOMessager.Message(text);
    }

    public void ResetConsole()
    {
        Console.Clear();
    }

    public void DrawBoard(in object[,] tiles)
    {
        var totalRanks = tiles.GetLength(0);
        var totalFiles = tiles.GetLength(1);

        for (var rank = totalRanks - 1; rank >= 0; --rank)
        {
            Console.Write(FormatTile(rank.ToString()));

            var consoleBackgroundColor = rank % 2 == 0 ? ConsoleColor.Green : ConsoleColor.Red;
            for (var file = 0; file < totalFiles; file++)
            {
                SetTileColor(tiles[rank, file], consoleBackgroundColor);
                var output = FormatTile(tiles[rank, file]?.GetType().GetProperty("Unicode").GetValue(tiles[rank, file]));

                Console.Write(output);
                Console.ResetColor();

                consoleBackgroundColor = consoleBackgroundColor == ConsoleColor.Green
                   ? ConsoleColor.Red : ConsoleColor.Green;
            }

            Console.Write("\r\n");
            Console.ResetColor();
        }

        Console.Write(FormatTile());
        for (var file = 0; file < totalFiles; file++)
        {
            Console.Write(FormatTile(file.ToString()));
        }
        Console.Write("\r\n");

        Console.WriteLine();
    }

    private void SetTileColor(object obj, ConsoleColor consoleBackgroundColor = ConsoleColor.Green)
    {
        Console.BackgroundColor = consoleBackgroundColor;
        Console.ForegroundColor = obj?.GetType().GetProperty("Color").GetValue(obj)
            .ToString()
            .Contains("White", StringComparison.OrdinalIgnoreCase) is true
                ? ConsoleColor.White : ConsoleColor.Black;
    }

    private string FormatTile(object? obj = null)
        => $"{new string(' ', _padding)}{obj ?? " "}{new string(' ', _padding)}";
}

using ChessLib;

namespace ChessConsoleLibrary;

internal class BoardDisplayer
{
    public static void ShowBoard(in IChessPiece[,]? tiles)
    {
        var totalRows = tiles.GetLength((int)ChessBoardFiles.Zero);
        var totalCols = totalRows;

        for (var row = 0; row < totalRows; ++row)
        {
            Console.Write($"Row {row}  ");
            for (var col = 0; col < totalCols; col++)
            {
                var consoleBackgroundColor = ((row % 2 != 0 && col % 2 == 0)
                    || (row % 2 == 0 && col % 2 != 0))
                    ? ConsoleColor.Red : ConsoleColor.Green;

                SetTileColor(tiles[row, col], consoleBackgroundColor);

                var output = FormatUnicode(tiles[row, col]?.Unicode, ChessBoard.TileWidth);
                DisplayPieceOrNull(output);
            }
            Console.WriteLine();
        }

        Console.WriteLine();
    }

    private static void SetTileColor(IChessPiece piece, ConsoleColor consoleBackgroundColor = ConsoleColor.Green)
    {
        Console.BackgroundColor = consoleBackgroundColor;
        Console.ForegroundColor = piece?.Color is ChessPieceColor.White
            ? ConsoleColor.White : ConsoleColor.Black;
    }

    private static string FormatUnicode(object unicode, int tileWidth)
        => $"{new string(' ', tileWidth / 2)}{unicode ?? "."}{new string(' ', tileWidth / 2)}";

    private static void DisplayPieceOrNull(object obj)
    {
        Console.Write(obj);

        Console.ResetColor();

        // it has been written to wait for resetting the color.
        Thread.Sleep(0);
    }
}

using ChessGame.Domain;

namespace ChessGame.Presentation;

internal class ConsoleOutput
{
    private int _tileWidth { get; } = 5;

    public void ShowBoard(in IChessPiece[,]? tiles)
    {
        var totalRows = tiles.GetLength((int)ChessBoardFile.Zero);
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

                var output = FormatUnicode(tiles[row, col]?.Unicode, _tileWidth);
                DisplayPieceOrNull(output);
            }
            Console.Write("\r\n");
        }

        Console.WriteLine();
    }

    private void SetTileColor(IChessPiece piece, ConsoleColor consoleBackgroundColor = ConsoleColor.Green)
    {
        Console.BackgroundColor = consoleBackgroundColor;
        Console.ForegroundColor = piece?.Color is ChessPieceColor.White
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

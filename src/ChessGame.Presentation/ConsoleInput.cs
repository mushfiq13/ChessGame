namespace ChessGame.Presentation;

internal class ConsoleInput
{
    private ConsoleIOMessager _iOMessager = new();

    public (int Row, int Col) ReadTilePosition()
    {
        var row = _iOMessager.RowColReader("row");
        var col = _iOMessager.RowColReader("column");

        return (row, col);
    }
}

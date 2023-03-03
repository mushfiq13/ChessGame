namespace ChessGame.Domain;

public abstract class Queen : ChessPiece
{
    public override ChessPieceColor Color { get; }
    public override string Unicode { get; }
    public abstract override (int Rank, int File) Position { get; set; }

    public Queen(ChessPieceColor color, string unicode)
    {
        Color = color;
        Unicode = unicode;
    }

    public override bool IsDestinationTileValid(int destRank, int destFile)
    {
        var xAxis = new[] { +1, +1, +0, -1, -1, -1, +0 };
        var yAxis = new[] { +0, +1, +1, +1, +0, -1, -1 };

        for (var i = 0; i < xAxis.Length; ++i)
        {
            if (IsDestinationTileFound(Position.Rank, Position.File, destRank, destFile, xAxis[i], yAxis[i]))
            {
                return true;
            }
        }

        return false;
    }

    private bool IsDestinationTileFound(int curRank, int curFile, int destRank, int destFile, int xAxis, int yAxis)
    {
        if (curRank == destRank && curFile == destFile)
            return true;
        if (curRank < 0 || curRank >= ChessConstants.RANKS || curFile < 0 || curFile >= ChessConstants.FILES)
            return false;

        return IsDestinationTileFound(curRank + xAxis, curFile + yAxis, destRank, destFile, xAxis, yAxis);
    }
}

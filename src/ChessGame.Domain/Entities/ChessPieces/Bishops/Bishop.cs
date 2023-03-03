namespace ChessGame.Domain;

public abstract class Bishop : ChessPiece
{
    public override ChessPieceColor Color { get; }
    public override string Unicode { get; }
    public abstract override (int Rank, int File) Position { get; set; }

    public Bishop(ChessPieceColor color, string unicode)
    {
        Color = color;
        Unicode = unicode;
    }

    public override bool IsDestinationTileValid(int destRank, int destFile)
    {
        return IsDestinationTileFound(Position.Rank, Position.File, destRank, destFile, +1, +1)
            || IsDestinationTileFound(Position.Rank, Position.File, destRank, destFile, +1, -1)
            || IsDestinationTileFound(Position.Rank, Position.File, destRank, destFile, -1, +1)
            || IsDestinationTileFound(Position.Rank, Position.File, destRank, destFile, -1, -1);
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

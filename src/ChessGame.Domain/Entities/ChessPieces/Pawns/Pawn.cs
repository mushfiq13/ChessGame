namespace ChessGame.Domain;

public abstract class Pawn : ChessPiece
{
    public override ChessPieceColor Color { get; }
    public override string Unicode { get; }
    public abstract override (int Rank, int File) Position { get; set; }

    public Pawn(ChessPieceColor color, string unicode)
    {
        Color = color;
        Unicode = unicode;
    }

    public override bool IsDestinationTileValid(int destRank, int destFile)
    {
        var rankDistance = Math.Abs(Position.Rank - destRank);
        var fileDistance = Math.Abs(Position.File - destFile);

        if (rankDistance == 1 && fileDistance == 1
            || (fileDistance == 0 && rankDistance == 1))
        {
            return true;
        }

        if (IsAtInitialPosition() == false && fileDistance == 0 && rankDistance == 2)
        {
            return true;
        }

        return false;
    }

    private bool IsAtInitialPosition()
        => Color == ChessPieceColor.White
            ? Position.Rank == (int)ChessBoardRank.One
            : Position.Rank == (int)ChessBoardRank.Six;
}

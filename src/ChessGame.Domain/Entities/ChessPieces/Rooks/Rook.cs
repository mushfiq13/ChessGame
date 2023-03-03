namespace ChessGame.Domain;

public abstract class Rook : ChessPiece
{
    public override ChessPieceColor Color { get; }
    public override string Unicode { get; }
    public abstract override (int Rank, int File) Position { get; set; }

    public Rook(ChessPieceColor color, string unicode)
    {
        Color = color;
        Unicode = unicode;
    }

    public override bool IsDestinationTileValid(int destRank, int destFile)
        => Position.Rank == destRank || Position.File == destFile;
}

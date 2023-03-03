namespace ChessGame.Domain;

public class BlackKnight : Knight
{
    public override (int Rank, int File) Position { get; set; }

    public BlackKnight(int knightPositionInFile)
        : base(ChessPieceColor.Black, ChessConstants.BLACK_KNIGHT_UNICODE)
    {
        Position = (ChessConstants.BLACK_KING_RANK, knightPositionInFile);
    }
}

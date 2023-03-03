namespace ChessGame.Domain;

public class BlackKing : King
{
    public override (int Rank, int File) Position { get; set; }

    public BlackKing()
        : base(ChessPieceColor.Black, ChessConstants.BLACK_KING_UNICODE)
    {
        Position = (ChessConstants.BLACK_KING_RANK, ChessConstants.KING_POSITION_IN_FILE);
    }
}

namespace ChessGame.Domain;

public class WhiteKing : King
{
    public override (int Rank, int File) Position { get; set; }

    public WhiteKing()
        : base(ChessPieceColor.White, ChessConstants.WHITE_KING_UNICODE)
    {
        Position = (ChessConstants.WHITE_KING_RANK, ChessConstants.KING_POSITION_IN_FILE);
    }
}

namespace ChessGame.Domain;

public class WhiteQueen : Queen
{
    public override (int Rank, int File) Position { get; set; }

    public WhiteQueen()
        : base(ChessPieceColor.White, ChessConstants.WHITE_QUEEN_UNICODE)
    {
        Position = (ChessConstants.WHITE_KING_RANK, ChessConstants.QUEEN_POSITION_IN_FILE);
    }
}

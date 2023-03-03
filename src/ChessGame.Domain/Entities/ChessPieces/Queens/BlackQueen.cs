namespace ChessGame.Domain;

public class BlackQueen : Queen
{
    public override (int Rank, int File) Position { get; set; }

    public BlackQueen()
        : base(ChessPieceColor.Black, ChessConstants.BLACK_QUEEN_UNICODE)
    {
        Position = (ChessConstants.BLACK_KING_RANK, ChessConstants.QUEEN_POSITION_IN_FILE);
    }
}

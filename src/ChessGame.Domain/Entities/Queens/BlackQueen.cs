namespace ChessGame.Domain;

public class BlackQueen : Queen
{
    public override ChessPieceColor Color => ChessPieceColor.Black;
    public override string Unicode => ChessConstants.BLACK_QUEEN_UNICODE;

    public BlackQueen()
        : base(ChessConstants.BLACK_KING_RANK, ChessConstants.QUEEN_POSITION_IN_FILE)
    { }
}

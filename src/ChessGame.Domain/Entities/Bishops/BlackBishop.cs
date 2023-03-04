namespace ChessGame.Domain;

public class BlackBishop : Bishop
{
    public override ChessPieceColor Color => ChessPieceColor.Black;
    public override string Unicode => ChessConstants.BLACK_BISHOP_UNICODE;

    public BlackBishop(int bishopPositionInFile)
       : base(ChessConstants.BLACK_KING_RANK, bishopPositionInFile)
    {
    }
}

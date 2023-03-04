namespace ChessGame.Domain;

public class WhiteBishop : Bishop
{
    public override ChessPieceColor Color => ChessPieceColor.White;
    public override string Unicode => ChessConstants.WHITE_BISHOP_UNICODE;

    public WhiteBishop(int bishopPositionInFile)
      : base(ChessConstants.WHITE_KING_RANK, bishopPositionInFile)
    {
    }
}

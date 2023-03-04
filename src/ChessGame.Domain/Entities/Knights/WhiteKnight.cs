namespace ChessGame.Domain;

public class WhiteKnight : Knight
{
    public override ChessPieceColor Color => ChessPieceColor.White;
    public override string Unicode => ChessConstants.WHITE_KNIGHT_UNICODE;

    public WhiteKnight(int knightPositionInFile)
       : base(ChessConstants.WHITE_KING_RANK, knightPositionInFile)
    {
    }
}

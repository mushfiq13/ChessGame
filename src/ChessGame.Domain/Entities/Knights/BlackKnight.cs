namespace ChessGame.Domain;

public class BlackKnight : Knight
{
    public override ChessPieceColor Color => ChessPieceColor.Black;
    public override string Unicode => ChessConstants.BLACK_KNIGHT_UNICODE;

    public BlackKnight(int knightPositionInFile)
        : base(ChessConstants.BLACK_KING_RANK, knightPositionInFile)
    {
    }
}

namespace ChessLib;

public class WhiteChessOpponent : ChessPlayer
{
    public override ChessPieceColor PieceColor => ChessPieceColor.White;

    public WhiteChessOpponent()
    {
        Initialization(PieceColor);
    }
}

namespace ChessLib;

public class BlackChessOpponent : ChessPlayer
{
    public override ChessPieceColor PieceColor => ChessPieceColor.Black;

    public BlackChessOpponent()
    {
        Initialization(PieceColor);
    }
}
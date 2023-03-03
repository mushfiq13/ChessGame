namespace ChessGame.Domain;

public class BlackChessPlayer : ChessPlayer
{
    public BlackChessPlayer()
        : base(ChessPieceColor.Black, (int)ChessBoardFile.Seven, (int)ChessBoardFile.Six)
    { }
}
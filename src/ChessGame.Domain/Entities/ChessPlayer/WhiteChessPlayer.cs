namespace ChessGame.Domain;

public class WhiteChessPlayer : ChessPlayer
{
    public WhiteChessPlayer()
        : base(ChessPieceColor.White, (int)ChessBoardFile.Zero, (int)ChessBoardFile.One)
    { }
}

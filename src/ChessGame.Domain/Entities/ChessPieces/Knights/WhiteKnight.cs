namespace ChessGame.Domain;

public class WhiteKnight : Knight
{
    public override (int Rank, int File) Position { get; set; }

    public WhiteKnight(int knightPositionInFile)
        : base(ChessPieceColor.White, ChessConstants.WHITE_KNIGHT_UNICODE)
    {
        Position = (ChessConstants.WHITE_KING_RANK, knightPositionInFile);
    }
}

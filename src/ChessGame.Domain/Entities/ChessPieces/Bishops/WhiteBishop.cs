namespace ChessGame.Domain;

public class WhiteBishop : Bishop
{
    public override (int Rank, int File) Position { get; set; }

    public WhiteBishop(int bishopPositionInFile)
       : base(ChessPieceColor.White, ChessConstants.WHITE_BISHOP_UNICODE)
    {
        Position = (ChessConstants.WHITE_KING_RANK, bishopPositionInFile);
    }
}

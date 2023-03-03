namespace ChessGame.Domain;

public class WhiteRook : Rook
{
    public override (int Rank, int File) Position { get; set; }

    public WhiteRook(int rookPositionInFile)
        : base(ChessPieceColor.White, ChessConstants.WHITE_ROOK_UNICODE)
    {
        Position = (ChessConstants.WHITE_KING_RANK, rookPositionInFile);
    }
}

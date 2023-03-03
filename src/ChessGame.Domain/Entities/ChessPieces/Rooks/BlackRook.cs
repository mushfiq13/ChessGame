namespace ChessGame.Domain;

public class BlackRook : Rook
{
    public override (int Rank, int File) Position { get; set; }

    public BlackRook(int rookPositionInFile)
        : base(ChessPieceColor.Black, ChessConstants.BLACK_ROOK_UNICODE)
    {
        Position = (ChessConstants.BLACK_KING_RANK, rookPositionInFile);
    }
}

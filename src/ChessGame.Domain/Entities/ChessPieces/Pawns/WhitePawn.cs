namespace ChessGame.Domain;

public class WhitePawn : Pawn
{
    public override (int Rank, int File) Position { get; set; }

    public WhitePawn(int pawnPositionInFile)
        : base(ChessPieceColor.White, ChessConstants.WHITE_PAWNS_UNICODE)
    {
        Position = (ChessConstants.WHITE_KING_RANK, pawnPositionInFile);
    }
}

namespace ChessGame.Domain;

public class BlackPawn : Pawn
{
    public override (int Rank, int File) Position { get; set; }

    public BlackPawn(int pawnPositionInFile)
       : base(ChessPieceColor.Black, ChessConstants.BLACK_PAWNS_UNICODE)
    {
        Position = (ChessConstants.BLACK_KING_RANK, pawnPositionInFile);
    }
}

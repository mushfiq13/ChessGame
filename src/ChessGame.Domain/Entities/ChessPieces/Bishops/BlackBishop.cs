namespace ChessGame.Domain;

public class BlackBishop : Bishop
{
    public override (int Rank, int File) Position { get; set; }

    public BlackBishop(int bishopPositionInFile)
       : base(ChessPieceColor.Black, ChessConstants.BLACK_BISHOP_UNICODE)
    {
        Position = (ChessConstants.BLACK_KING_RANK, bishopPositionInFile);
    }
}

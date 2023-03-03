namespace ChessGame.Domain;

public class WhiteChessPlayer : ChessPlayer
{
    public override ChessPieceColor PieceColor { get; }
    public override IChessPiece King { get; }
    public override IChessPiece Queen { get; }
    public override (IChessPiece, IChessPiece) Knight { get; }
    public override (IChessPiece, IChessPiece) Bishop { get; }
    public override (IChessPiece, IChessPiece) Rook { get; }
    public override IList<IChessPiece> Pawns { get; }

    public WhiteChessPlayer()
    {
        PieceColor = ChessPieceColor.White;

        King = Factory.CreateWhiteKing();
        Queen = Factory.CreateWhiteQueen();
        Knight = (
            Factory.CreateWhiteKnight(ChessConstants.KNIGHT_POSITION.File1),
            Factory.CreateWhiteKnight(ChessConstants.KNIGHT_POSITION.File2));
        Bishop = (
            Factory.CreateWhiteBishop(ChessConstants.BISHOP_POSITION.File1),
            Factory.CreateWhiteBishop(ChessConstants.BISHOP_POSITION.File2));
        Rook = (
            Factory.CreateWhiteRook(ChessConstants.ROOK_POSITION.File1),
            Factory.CreateWhiteRook(ChessConstants.ROOK_POSITION.File2));

        Pawns = new List<IChessPiece>();

        foreach (var file in ChessConstants.PAWN_POSITION_IN_FILE)
        {
            Pawns.Add(Factory.CreateWhitePawn(file));
        }
    }
}
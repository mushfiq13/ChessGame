namespace ChessGame.Domain;

public class BlackChessPlayer : ChessPlayer
{
    public override ChessPieceColor PieceColor { get; }
    public override IChessPiece King { get; }
    public override IChessPiece Queen { get; }
    public override (IChessPiece, IChessPiece) Knight { get; }
    public override (IChessPiece, IChessPiece) Bishop { get; }
    public override (IChessPiece, IChessPiece) Rook { get; }
    public override IList<IChessPiece> Pawns { get; }

    public BlackChessPlayer()
    {
        PieceColor = ChessPieceColor.Black;

        King = Factory.CreateBlackKing();
        Queen = Factory.CreateBlackQueen();
        Knight = (
            Factory.CreateBlackKnight(ChessConstants.KNIGHT_POSITION.File1),
            Factory.CreateBlackKnight(ChessConstants.KNIGHT_POSITION.File2));
        Bishop = (
            Factory.CreateBlackBishop(ChessConstants.BISHOP_POSITION.File1),
            Factory.CreateBlackBishop(ChessConstants.BISHOP_POSITION.File2));
        Rook = (
            Factory.CreateBlackRook(ChessConstants.ROOK_POSITION.File1),
            Factory.CreateBlackRook(ChessConstants.ROOK_POSITION.File2));

        Pawns = new List<IChessPiece>();

        foreach (var file in ChessConstants.PAWN_POSITION_IN_FILE)
        {
            Pawns.Add(Factory.CreateBlackPawn(file));
        }
    }
}
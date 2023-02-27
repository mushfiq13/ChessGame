namespace ChessLib;

public abstract class ChessPlayer : IChessPlayer
{
    public ChessPieceColor PieceColor { get; }
    public IChessPiece King { get; protected set; }
    public IChessPiece Queen { get; protected set; }
    public (IChessPiece, IChessPiece) Knight { get; protected set; }
    public (IChessPiece, IChessPiece) Bishop { get; protected set; }
    public (IChessPiece, IChessPiece) Rook { get; protected set; }
    public IList<IChessPiece> Pawns { get; protected set; }

    public ChessPlayer(ChessPieceColor color)
    {
        PieceColor = color;

        King = Factory.CreateKing(color);
        Queen = Factory.CreateQueen(color);
        Knight = (Factory.CreateKnight(color), Factory.CreateKnight(color));
        Bishop = (Factory.CreateBishop(color), Factory.CreateBishop(color));
        Rook = (Factory.CreateRook(color), Factory.CreateRook(color));

        Pawns = new List<IChessPiece>();
        for (var i = 0; i < ChessBoard.Ranks; ++i)
        {
            Pawns.Add(Factory.CreatePawns(color));
        }
    }
}

namespace ChessGame.Domain;

public abstract class ChessPlayer : IChessPlayer
{
    public ChessPieceColor PieceColor { get; }
    public IChessPiece King { get; }
    public IChessPiece Queen { get; }
    public (IChessPiece, IChessPiece) Knight { get; }
    public (IChessPiece, IChessPiece) Bishop { get; }
    public (IChessPiece, IChessPiece) Rook { get; }
    public IList<IChessPiece> Pawns { get; }
    public bool IsResigned { get; set; } = false;
    public bool IsWinner { get; set; } = false;
    public bool IsCheckmate { get; set; } = false;

    public ChessPlayer(ChessPieceColor color, int kingPlaceableRank, int pawnsPlaceableRank)
    {
        PieceColor = color;

        King = Factory.CreateKing(color, kingPlaceableRank, (int)ChessBoardRank.Four);
        Queen = Factory.CreateQueen(color, kingPlaceableRank, (int)ChessBoardRank.Three);

        Knight = (Factory.CreateKnight(color, kingPlaceableRank, (int)ChessBoardRank.One),
            Factory.CreateKnight(color, kingPlaceableRank, (int)ChessBoardRank.Six));

        Bishop = (Factory.CreateBishop(color, kingPlaceableRank, (int)ChessBoardRank.Two),
            Factory.CreateBishop(color, kingPlaceableRank, (int)ChessBoardRank.Five));

        Rook = (Factory.CreateRook(color, kingPlaceableRank, (int)ChessBoardRank.Zero),
            Factory.CreateRook(color, kingPlaceableRank, (int)ChessBoardRank.Seven));

        Pawns = new List<IChessPiece>();

        for (var rank = 0; rank < ChessConstants.FILES; ++rank)
        {
            Pawns.Add(Factory.CreatePawns(color, pawnsPlaceableRank, rank));
        }
    }
}

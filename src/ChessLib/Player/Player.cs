namespace ChessLib;

public class Player : IPlayer
{
    public ChessPieceColor PieceColor { get; }
    public KingModel King { get; }
    public QueenModel Queen { get; }
    public KnightModel Knight { get; }
    public BishopModel Bishop { get; }
    public RookModel Rook { get; }
    public PawnsModel Pawns { get; }

    public Player(ChessPieceColor chessPieceColor)
    {
        PieceColor = chessPieceColor;
        King = new KingModel(PieceColor);
        Queen = new QueenModel(PieceColor);
        Knight = new KnightModel(PieceColor);
        Bishop = new BishopModel(PieceColor);
        Rook = new RookModel(PieceColor);
        Pawns = new PawnsModel(PieceColor);
    }
}

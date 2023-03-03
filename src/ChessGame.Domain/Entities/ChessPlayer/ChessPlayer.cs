namespace ChessGame.Domain;

public abstract class ChessPlayer : IChessPlayer
{
    public abstract ChessPieceColor PieceColor { get; }
    public abstract IChessPiece King { get; }
    public abstract IChessPiece Queen { get; }
    public abstract (IChessPiece, IChessPiece) Knight { get; }
    public abstract (IChessPiece, IChessPiece) Bishop { get; }
    public abstract (IChessPiece, IChessPiece) Rook { get; }
    public abstract IList<IChessPiece> Pawns { get; }
    public bool IsResigned { get; set; } = false;
    public bool IsWinner { get; set; } = false;
    public bool IsCheckmate { get; set; } = false;
}

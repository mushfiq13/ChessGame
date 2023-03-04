namespace ChessGame.Domain;

public interface IChessPlayer
{
    ChessPieceColor PieceColor { get; }
    (IChessPiece, IChessPiece) Bishop { get; }
    IChessPiece King { get; }
    (IChessPiece, IChessPiece) Knight { get; }
    IList<IChessPiece> Pawns { get; }
    IChessPiece Queen { get; }
    (IChessPiece, IChessPiece) Rook { get; }
    bool IsWinner { get; }
    bool IsCheckmate { get; }
    bool IsResigned { get; }

    void Resign();
    void Winned();
    void Checkmate();
    void ClearCheckmate();
}
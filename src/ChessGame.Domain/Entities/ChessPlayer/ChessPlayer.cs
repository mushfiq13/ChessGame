namespace ChessGame.Domain;

public abstract class ChessPlayer : IChessPlayer
{
    bool _isResigned = false;
    bool _isWinner = false;
    bool _isCheckMate = false;

    public abstract ChessPieceColor PieceColor { get; }
    public abstract IChessPiece King { get; }
    public abstract IChessPiece Queen { get; }
    public abstract (IChessPiece, IChessPiece) Knight { get; }
    public abstract (IChessPiece, IChessPiece) Bishop { get; }
    public abstract (IChessPiece, IChessPiece) Rook { get; }
    public abstract IList<IChessPiece> Pawns { get; }
    public bool IsWinner => _isWinner;
    public bool IsResigned => _isResigned;
    public bool IsCheckmate => _isCheckMate;

    public void Resign() => _isResigned = true;

    public void Winned() => _isWinner = true;

    public void Checkmate() => _isCheckMate = true;

    public void ClearCheckmate() => _isCheckMate = _isCheckMate ? false : _isCheckMate;
}

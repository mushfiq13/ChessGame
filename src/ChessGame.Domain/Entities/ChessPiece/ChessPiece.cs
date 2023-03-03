namespace ChessGame.Domain;

public abstract class ChessPiece : IChessPiece
{
    public ChessPieceColor Color { get; }
    public bool IsAlive { get; set; } = true;
    public string Unicode { get; private set; }
    public (int Rank, int File) Position { get; set; }

    public ChessPiece(ChessPieceType type, ChessPieceColor color, (int, int) position)
    {
        Color = color;
        Unicode = GetUnicode(type, color);
        Position = position;
    }

    private string GetUnicode(ChessPieceType type, ChessPieceColor chessPieceColor)
    {
        return type switch
        {
            ChessPieceType.King => chessPieceColor == ChessPieceColor.White
                ? ChessConstants.WHITE_KING_UNICODE : ChessConstants.BLACK_KING_UNICODE,
            ChessPieceType.Queen => chessPieceColor == ChessPieceColor.White
                ? ChessConstants.WHITE_QUEEN_UNICODE : ChessConstants.BLACK_QUEEN_UNICODE,
            ChessPieceType.Rook => chessPieceColor == ChessPieceColor.White
                ? ChessConstants.WHITE_ROOK_UNICODE : ChessConstants.BLACK_ROOK_UNICODE,
            ChessPieceType.Bishop => chessPieceColor == ChessPieceColor.White
                ? ChessConstants.WHITE_BISHOP_UNICODE : ChessConstants.BLACK_BISHOP_UNICODE,
            ChessPieceType.Knight => chessPieceColor == ChessPieceColor.White
                ? ChessConstants.WHITE_KING_UNICODE : ChessConstants.BLACK_KING_UNICODE,
            ChessPieceType.Pawns => chessPieceColor == ChessPieceColor.White
                ? ChessConstants.WHITE_PAWNS_UNICODE : ChessConstants.BLACK_PAWNS_UNICODE,
            _ => string.Empty,
        };
    }
}

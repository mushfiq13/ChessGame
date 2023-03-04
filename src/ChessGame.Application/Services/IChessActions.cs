using ChessGame.Domain;

namespace ChessGame.Application;

internal interface IChessActions
{
    void MovePiece(IChessPiece piece, int targetRank, int targetFile);
    void RemovePiece(int rank, int file);
    void TogglePlayer();
}

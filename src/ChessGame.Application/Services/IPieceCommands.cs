using ChessGame.Domain;

namespace ChessGame.Application;

internal interface IPieceCommands
{
    void MovePiece(IChessPiece piece, int targetRank, int targetFile);
    void KillPiece(IChessPiece piece);
}

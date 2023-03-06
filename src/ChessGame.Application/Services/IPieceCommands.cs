using ChessGame.Domain;

namespace ChessGame.Application;

internal interface IPieceCommands
{
    void MovePiece(IChess piece, int targetRank, int targetFile);
    void KillPiece(IChess piece);
}

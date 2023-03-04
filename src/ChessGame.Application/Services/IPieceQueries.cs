using ChessGame.Domain;

namespace ChessGame.Application;

internal interface IPieceQueries
{
    bool IsPieceMoveable(IChessPiece piece, int targetRank, int targetFile);
    bool IsOpponentsPiece(IChessPiece curPiece, int targetRank, int targetFile);
    bool IsPlayersChoiceValid(int curRank, int curFile, int targetRank, int targetFile);
}

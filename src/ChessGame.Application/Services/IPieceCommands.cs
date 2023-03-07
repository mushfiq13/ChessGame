using ChessGame.Domain;

namespace ChessGame.Application
{
    internal interface IPieceCommands
    {
        void Kill(IChess item);
        bool Move(IChess item, int targetRank, int targetFile);
    }
}
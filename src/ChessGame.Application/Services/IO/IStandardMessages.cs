using ChessGame.Domain;

namespace ChessGame.Application
{
    internal interface IStandardMessages
    {
        void EndApplication();
        void WinnerMessages(IChess? winner);
    }
}
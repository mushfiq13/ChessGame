using ChessGame.ConsoleUI;
using ChessGame.Domain;

namespace ChessGame.Application
{
    internal interface IAppFactory
    {
        ICaptureProcessor CaptureProcessor { get; }
        IChessHandler ChessHandler { get; }
        IGameExecutor GameExecutor { get; }
        IOutputHandler OutputHandler { get; }
        IChessServiceProvider ChessManager { get; }
        IConsoleUIManager ConsoleUIManager { get; }
    }
}
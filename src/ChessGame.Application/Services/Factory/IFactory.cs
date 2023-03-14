using ChessGame.Domain;

namespace ChessGame.Application;

internal interface IFactory
{
    ICaptureProcessor GetCaptureProcessorInstance(IChessBoard board);
    IChessBoard CreateChessBoardInstance();
    IChessHandler GetChessHandlerInstance(IChessBoard board);
    IGameExecutor GetGameExecutorInstance(IChessBoard board);
    IOutputHandler GetOutputHandlerInstance();
}
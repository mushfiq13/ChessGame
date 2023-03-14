using ChessGame.Domain;

namespace ChessGame.Application;

internal interface IFactory
{
    ICaptureProcessor GetCaptureProcessorInstance(IChessBoard board);
    IChessHandler GetChessHandlerInstance(IChessBoard board);
    IGameExecutor GetGameExecutorInstance(IChessBoard board);
    IOutputHandler GetOutputHandlerInstance();
}
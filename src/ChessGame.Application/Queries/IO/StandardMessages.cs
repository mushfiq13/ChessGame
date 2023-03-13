using ChessGame.ConsoleUI;
using ChessGame.Domain;

namespace ChessGame.Application;

internal class StandardMessages : IStandardMessages
{
    private readonly ILogger _logger;

    public StandardMessages(ILogger logger)
    {
        _logger = logger;
    }

    public void WinnerMessages(IChess? winner)
    {
        if (winner is not null)
        {
            _logger.LogInformation("Congratulations!");
            _logger.LogInformation(
                $"{(winner.Color == ChessColor.White ? "White" : "Black")} Chess player won.");
        }
        else
        {
            _logger.LogInformation("Unfortunately the game ended with Draw!");
        }
    }

    public void EndApplication()
    {
        _logger.LogWarning("Closing Application...");
    }
}

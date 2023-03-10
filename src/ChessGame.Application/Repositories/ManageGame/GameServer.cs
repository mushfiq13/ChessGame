using ChessGame.Domain;

namespace ChessGame.Application;

internal class GameServer : IGameServer
{
    IChessDataCapture _dataCapturer = Factory.CreateChessDataCapture();
    IChessHandler _handler = Factory.CreateChessHandler();

    public IList<IChessCore> WhiteCaptured { get; private set; } = new List<IChessCore>();
    public IList<IChessCore> BlackCaptured { get; private set; } = new List<IChessCore>();
    public bool WhiteInTurn { get; private set; } = true;
    public IChessCore? Winner { get; private set; }

    public void Run()
    {
        var currentPlayerTriedInvalidMove = 0;

        while (GameOver() is false && currentPlayerTriedInvalidMove < 5)
        {
            Singleton.ConsoleOutput.DrawUI(WhiteInTurn ? "White" : "Black",
                WhiteCaptured.ToArray(),
                BlackCaptured.ToArray());

            var captured = _dataCapturer.Capture(WhiteInTurn
                ? ChessColor.White
                : ChessColor.Black);

            if (captured == null)
            {
                currentPlayerTriedInvalidMove++;
                continue;
            }

            var target = Singleton.BoardManager.Tiles[(int)captured?.target.rank,
                (int)captured?.target.file];

            if (target is not null)
            {
                _handler.Kill(target);
                StoreKilledChess(target);
                Winner = ChessDataGetter.IsKingsUnicode(target?.Unicode)
                    ? captured?.source : null;
            }

            _handler.Move(captured?.source,
                (int)captured?.target.rank,
                (int)captured?.target.file);

            TogglePlayer();
            Singleton.ConsoleMessages.WriteMessage("\nUpdating....");
            Thread.Sleep(1 * 2000);
            Singleton.ConsoleOutput.ResetConsole();
            currentPlayerTriedInvalidMove = 0;
        }
    }

    public void Clear()
    {
        WhiteCaptured.Clear();
        BlackCaptured.Clear();
        WhiteInTurn = true;
        Winner = null;
    }

    public void Dispose()
    {
        WhiteCaptured.Clear();
        BlackCaptured.Clear();
        _dataCapturer = null;
        _handler = null;
    }

    private bool GameOver() => Winner is not null;

    private void TogglePlayer() => WhiteInTurn = !WhiteInTurn;

    private void StoreKilledChess(IChess item)
    {
        if (item is null) return;

        if (item.Color == ChessColor.White)
            WhiteCaptured.Add(item);
        else
            BlackCaptured.Add(item);
    }
}

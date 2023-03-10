using ChessGame.Domain;

namespace ChessGame.Application;

internal class GameServer : IGameServer
{
    IChessHandler _handler = Factory.CreateChessHandler();
    ICaptureProcessor _captureProcessor = Factory.CreateCaptureProcessor();

    public IList<IChessCore> WhiteCaptured { get; private set; } = new List<IChessCore>();
    public IList<IChessCore> BlackCaptured { get; private set; } = new List<IChessCore>();
    public bool WhiteInTurn { get; private set; } = true;
    public IChessCore? Winner { get; private set; }

    public void Run()
    {
        var currentPlayerTriedInvalidMove = 0;

        while (GameOver() is false && currentPlayerTriedInvalidMove < 5)
        {
            var movingColor = WhiteInTurn ? ChessColor.White : ChessColor.Black;

            if (currentPlayerTriedInvalidMove == 0)
                Singleton.ConsoleOutput.DrawUI(WhiteInTurn ? "White" : "Black",
                    WhiteCaptured.ToArray(),
                    BlackCaptured.ToArray());

            var capturedData = _captureProcessor.Run(movingColor);
            var sourceChess = capturedData.sourceChess;
            var targetTile = capturedData.targetTile;

            if (sourceChess is null || targetTile is null)
            {
                return;
            }

            var tarRank = targetTile.Value.rank;
            var tarFile = targetTile.Value.file;
            IChess? targetChess = Singleton.ChessBoard[tarRank, tarFile];

            _handler.Kill(targetChess);
            StoreKilledChess(targetChess);

            Winner = ChessDataGetter.IsKingsUnicode(targetChess?.Unicode)
                ? sourceChess : null;

            _handler.Move(sourceChess, tarRank, tarFile);

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

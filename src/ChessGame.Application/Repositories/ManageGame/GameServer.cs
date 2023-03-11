using ChessGame.Domain;

namespace ChessGame.Application;

internal class GameServer : IGameServer
{
    IChessHandler _handler = Factory.CreateChessHandler();

    public IList<IChessCore> WhiteCaptured { get; private set; } = new List<IChessCore>();
    public IList<IChessCore> BlackCaptured { get; private set; } = new List<IChessCore>();
    public bool WhiteInTurn { get; private set; } = true;
    public IChessCore? Winner { get; private set; }

    public void Run()
    {
        while (GameOver() is false)
        {
            Singleton.IO.Output.PrintLogo();
            Singleton.IO.Output.DrawBoard(Singleton.ChessBoard.Tiles);
            Singleton.IO.Output.PrintCapturedItems(WhiteCaptured.ToArray(), "WHITE");
            Singleton.IO.Output.PrintCapturedItems(BlackCaptured.ToArray(), "BLACK");
            Singleton.IO.Output.CurrentTurn(WhiteInTurn ? "White" : "Black");

            var movingColor = WhiteInTurn ? ChessColor.White : ChessColor.Black;
            var capturedData = Singleton.CaptureProcessor.Run(movingColor);
            var sourceChess = capturedData.sourceChess;
            var targetTile = capturedData.targetTile;

            if (targetTile.rank == -1 || targetTile.file == -1)
            {
                return;
            }

            IChess? targetChess = Singleton.ChessBoard[targetTile.rank, targetTile.file];

            _handler.Kill(targetChess);
            StoreKilledChess(targetChess);

            Winner = ChessDataGetter.IsKingsUnicode(targetChess?.Unicode)
                ? sourceChess : null;

            _handler.Move(sourceChess, targetTile.rank, targetTile.file);

            TogglePlayer();
            Singleton.Logger.Log("\nUpdating...");
            Thread.Sleep(1 * 2000);
            Singleton.IO.Output.ResetConsole();
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

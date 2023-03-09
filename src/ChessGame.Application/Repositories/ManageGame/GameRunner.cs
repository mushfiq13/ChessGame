using ChessGame.Domain;

namespace ChessGame.Application;

public partial class GameManager
{
    IChessDataCapture _dataCapturer = Factory.CreateChessDataCapture();
    IChessManipulator _manipulator = Factory.CreateChessManipulator();

    private void Run()
    {
        while (GameOver is false)
        {
            var captured = _dataCapturer.Capture(
                _boardManager.Tiles,
                WhiteInTurn ? ChessColor.White : ChessColor.Black);

            if (captured.source.IsMoveable(_boardManager.Tiles,
                captured.target.rank,
                captured.target.file) == false)
            {
                _consoleCommands.InvalidDataCapture();
                _consoleCommands.WriteMessage("Try Again!\n");
                continue;
            }

            var target = _boardManager.Tiles[captured.target.rank, captured.target.file];

            if (target is not null)
            {
                if (WhiteInTurn) WhiteCaptured.Add(target);
                else BlackCaptured.Add(target);

                _manipulator.Kill(_boardManager, target);
                // We just killed the king!
                if (ChessDataGetter.IsKingsUnicode(target.Unicode))
                    SetCurrentTurnerAsWinner();
            }

            _manipulator.Move(_boardManager, captured.source,
                captured.target.rank,
                captured.target.file);

            TogglePlayer();

            _consoleCommands.WriteMessage("\nUpdating....");

            Thread.Sleep(1 * 2000);

            _consoleCommands.ResetConsole();
            _consoleCommands.DrawUI(_boardManager.Tiles,
                WhiteInTurn ? "White" : "Black",
                WhiteCaptured.ToArray(),
                BlackCaptured.ToArray());
        }
    }
}

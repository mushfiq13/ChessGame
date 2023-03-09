using ChessGame.Domain;

namespace ChessGame.Application;

public partial class GameManager : GameCoreManager, IGameManager
{
    IBoardManager _boardManager = Factory.CreateBoardManager();
    IUICommands _consoleCommands = Factory.CreateConsoleUICommands();

    public IList<IChessCore> WhiteCaptured { get; private set; } = new List<IChessCore>();
    public IList<IChessCore> BlackCaptured { get; private set; } = new List<IChessCore>();

    public override void Play()
    {
        GenerateChess.CreateChessSet(_boardManager, ChessColor.White);
        GenerateChess.CreateChessSet(_boardManager, ChessColor.Black);

        _consoleCommands.DrawUI(_boardManager.Tiles,
            WhiteInTurn ? "White" : "Black",
            WhiteCaptured.ToArray(),
            BlackCaptured.ToArray());

        Run();
    }

    private void SetCurrentTurnerAsWinner()
    {
        if (WhiteInTurn)
            Winner = ChessColor.White;
        else
            Winner = ChessColor.Black;
    }

    private void TogglePlayer() => WhiteInTurn = !WhiteInTurn;

    public void Dispose()
    {
        _boardManager = null;
        _consoleCommands = null;
        WhiteCaptured.Clear();
        BlackCaptured.Clear();
    }
}

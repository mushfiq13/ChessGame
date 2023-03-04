namespace ChessGame.Application;

internal interface IInputCommands
{
    (int rank, int file) SelecteTile();
    (int rank, int file) ChoseTargetTile();
}

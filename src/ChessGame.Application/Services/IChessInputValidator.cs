namespace ChessGame.Application;

internal interface IChessInputValidator
{
    bool IsSelectionValid(int rank, int file);
}

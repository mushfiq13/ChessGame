namespace ChessGame.Application;

public partial class ChessManager
{
    private (int srcRank, int srcFile, int targetRank, int targetFile) AskUser()
    {
        (int srcRank, int srcFile) = GetSelectedTile(_inputCommands.SelecteTile);
        (int targetRank, int targetFile) = GetSelectedTile(_inputCommands.ChoseTargetTile);

        return (srcRank, srcFile, targetRank, targetFile);
    }

    private (int rank, int file) GetSelectedTile(Func<(int, int)> inputMethod)
    {
        int rank;
        int file;

        do
        {
            (rank, file) = inputMethod();
        } while (_inputQueries.IsTileExist(rank, file) is false);

        return (rank, file);
    }
}

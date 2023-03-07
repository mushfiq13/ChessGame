namespace ChessGame.Application;

public partial class ChessManager
{
    private (int srcRank, int srcFile, int targetRank, int targetFile) Capture()
    {
        (int srcRank, int srcFile) = GetCapturedTile(_inputCommands.CaptureSourceTile);
        (int targetRank, int targetFile) = GetCapturedTile(_inputCommands.CaptureTargetTile);

        return (srcRank, srcFile, targetRank, targetFile);
    }

    private (int rank, int file) GetCapturedTile(Func<(int, int)> capture)
    {
        int rank;
        int file;

        do
        {
            (rank, file) = capture();
        } while (_inputQueries.IsFileAndRankValid(rank, file) is false);

        return (rank, file);
    }
}

using ChessGame.Domain;

namespace ChessGame.Application;

public partial class GameManager
{
    private (int srcRank, int srcFile, int targetRank, int targetFile) Capture()
    {
        (int srcRank, int srcFile) = GetCapturedTile(_UICommands.CaptureSourceTile);
        (int targetRank, int targetFile) = GetCapturedTile(_UICommands.CaptureTargetTile);

        return (srcRank, srcFile, targetRank, targetFile);
    }

    private (int rank, int file) GetCapturedTile(Func<(int, int)> capture)
    {
        int rank;
        int file;

        do
        {
            (rank, file) = capture();
        } while (ChessQuery.IsRankAndFileValid(rank, file) is false);

        return (rank, file);
    }
}

namespace ChessGame.Domain;

internal class ChessValidator : I2DChessValidator
{
    private static readonly I2DChessValidator _instance = new ChessValidator();

    private ChessValidator()
    {
    }

    public static I2DChessValidator GetChessValidator()
    {
        return _instance;
    }

    public bool canSourceChessMoveToTargetTile(IChess[,] tiles,
        IChess sourceChess,
       (int rank, int file) targetTile,
       int[] xDir,
       int[] yDir,
       int sourceChessCanJumpAtMost = int.MaxValue)
    {
        // Running BFS

        var queue = new Queue<(int, int, int)>();
        var map = new byte[ChessConstants.RANKS, ChessConstants.FILES];

        queue.Enqueue((sourceChess.Rank, sourceChess.File, 0));
        map[sourceChess.Rank, sourceChess.File] = 1;

        while (queue.Count > 0)
        {
            (int curRank, int curFile, int steps) = queue.Dequeue();

            if (steps >= sourceChessCanJumpAtMost) continue;

            for (var i = 0; i < xDir.Length; i++)
            {
                var nextRank = curRank + xDir[i];
                var nextFile = curFile + yDir[i];

                if (Inbounds(nextRank, nextFile) == false || map[nextRank, nextFile] != 0)
                    continue;
                if (sourceChess?.Color != tiles[nextRank, nextFile]?.Color
                    && (nextRank, nextFile) == targetTile)
                    return true;
                if (tiles[nextRank, nextFile] is not null)
                    return false; // source and target are not same. But source can not go through to this chess                

                if (steps < sourceChessCanJumpAtMost)
                {
                    queue.Enqueue((nextRank, nextFile, steps + 1));
                    map[nextRank, nextFile] = 1;
                }
            }
        }

        return false;
    }

    public bool Inbounds(int rank, int file)
       => rank > -1 && rank < ChessConstants.RANKS
            && file > -1 && file < ChessConstants.FILES;
}

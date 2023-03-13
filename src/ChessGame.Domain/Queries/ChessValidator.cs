namespace ChessGame.Domain;

internal class ChessValidator : IChessValidator
{
    public bool canSourceChessMoveToTargetTile(IChessBase[,] tiles,
        IChessBase sourceChess,
       (int rank, int file) targetTile,
       int[] xDir,
       int[] yDir,
       int chessCanJumpAtMost = int.MaxValue)
    {
        var queue = new Queue<(int, int, int)>();
        var map = new byte[ChessConstants.RANKS, ChessConstants.FILES];

        queue.Enqueue((sourceChess.Rank, sourceChess.File, 0));
        map[sourceChess.Rank, sourceChess.File] = 1;

        while (queue.Count > 0)
        {
            (int curRank, int curFile, int steps) = queue.Dequeue();

            if (steps >= chessCanJumpAtMost) continue;

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

                if (steps < chessCanJumpAtMost)
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

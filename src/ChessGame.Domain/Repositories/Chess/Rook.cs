﻿namespace ChessGame.Domain;

public class Rook : Chess
{
    public Rook(ChessColor color, string unicode, int rank, int file)
        : base(color, unicode, rank, file)
    {
    }

    public override bool Move(in IChess[,] tiles, int targetRank, int targetFile)
    {
        // Find in which director to go.
        var xAxis = Rank == targetRank ? +0
            : targetRank > Rank ? +1
            : -1;
        var yAxis = File == targetFile ? +0
            : targetFile > File ? +1
            : -1;

        if (IsAlive && ChessQuery.CanChessMoveTarget(tiles, Rank, File,
            targetRank, targetFile, xAxis, yAxis))
        {
            ResetPosition(targetRank, targetFile);

            return true;
        }

        return false;
    }
}

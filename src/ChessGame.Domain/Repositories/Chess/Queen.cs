﻿namespace ChessGame.Domain;

public class Queen : Chess
{
    public Queen(ChessColor color, string unicode, int rank, int file)
        : base(color, unicode, rank, file)
    {
    }

    public override bool Move(in IChess[,] tiles, int targetRank, int targetFile)
    {
        // Queen can go only to these directoins.
        var xAxis = new[] { +1, +1, +0, -1, -1, -1, +0 };
        var yAxis = new[] { +0, +1, +1, +1, +0, -1, -1 };

        if (IsAlive && ChessQuery.CanChessMoveTarget(tiles, Rank, File,
            targetRank, targetFile, xAxis, yAxis))
        {
            ResetPosition(targetRank, targetFile);

            return true;
        }

        return false;
    }
}
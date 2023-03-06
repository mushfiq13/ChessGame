﻿namespace ChessGame.Domain;

public class Knight : Chess
{
    public Knight(ChessColor color, string unicode, int rank, int file)
        : base(color, unicode, rank, file)
    {
    }

    public override bool Move(in IChess[,] tiles, int targetRank, int targetFile)
    {
        // Knight can go only to these directoins.
        var xAxis = new[] { +2, +1, -1, -2, -2, -1, +1, +2 };
        var yAxis = new[] { +1, +2, +2, +1, -1, -2, -2, -1 };

        if (IsAlive && ChessQuery.CanChessMoveTarget(tiles, Rank, File, targetRank, targetFile, xAxis, yAxis))
        {
            ResetPosition(targetRank, targetFile);

            return true;
        }

        return false;
    }
}
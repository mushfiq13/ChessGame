namespace ChessGame.Domain;

public abstract class Knight : ChessPiece
{
    public override ChessPieceColor Color { get; }
    public override string Unicode { get; }
    public abstract override (int Rank, int File) Position { get; set; }

    public Knight(ChessPieceColor color, string unicode)
    {
        Color = color;
        Unicode = unicode;
    }

    public override bool IsDestinationTileValid(int destRank, int destFile)
    {
        var xAxis = new[] { +2, +1, -1, -2, -2, -1, +1, +2 };
        var yAxis = new[] { +1, +2, +2, +1, -1, -2, -2, -1 };

        for (var i = 0; i < xAxis.Length; ++i)
        {
            if (Position.Rank + xAxis[i] == destRank && Position.File + yAxis[i] == destFile)
                return true;
        }

        return false;
    }
}

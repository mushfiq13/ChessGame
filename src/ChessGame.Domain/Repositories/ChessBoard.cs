namespace ChessGame.Domain;

public class ChessBoard : IChessBoard
{
    public int Count { get; private set; } = 0;
    public IChess[,] Tiles { get; private set; }

    public ChessBoard() => Tiles = Factory.CreateTiles();

    public void Add(IChess item)
    {
        Tiles[item.Rank, item.File] = item;

        ++Count;
    }

    public bool Contains(IChess item)
        => ChessQuery.IsChessLocationValid(item) && Tiles[item.Rank, item.File].Equals(item);

    public void Move(IChess item, int targetRank, int targetFile) => Tiles[targetRank, targetFile] = item;

    public void Dead(IChess item)
    {
        Tiles[item.Rank, item.File] = default;

        --Count;
    }

    public void Remove(int rank, int file) => Tiles[rank, file] = default;
}

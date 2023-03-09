namespace ChessGame.Domain;

public class ChessBoard : IBoardManager
{
    public IChess[,] Tiles { get; private set; }

    public ChessBoard(IChess[,] tiles) => Tiles = tiles;

    public void Add(in IChess item) => Tiles[item.Rank, item.File] = item;

    public void SetTo(in IChess item, int newRank, int newFile)
        => Tiles[newRank, newFile] = item;

    public void Remove(int rank, int file) => Tiles[rank, file] = null;

    public void Clear() => Tiles = default;
}

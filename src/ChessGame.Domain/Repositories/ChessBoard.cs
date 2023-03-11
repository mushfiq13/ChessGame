namespace ChessGame.Domain;

public class ChessBoard : IChessBoard
{
    IChess[,] _tiles;

    public IChess[,] Tiles => _tiles;

    public ChessBoard(IChess[,] tiles) => _tiles = tiles;

    public IChess this[int rank, int file]
    {
        get
        {
            try
            {
                return _tiles[rank, file];
            }
            catch
            {
                throw new IndexOutOfRangeException();
            }
        }
        set
        {
            _tiles[rank, file] = value;
        }
    }

    public IChessBoard Add(IChess item)
    {
        if (_tiles[item.Rank, item.File] is not null)
            throw new InvalidOperationException(
                $"Chess location is [{item.Rank}, {item.File}]" +
                $"which is already occupied by another chess.");

        _tiles[item.Rank, item.File] = item;

        return this;
    }

    public IChessBoard Put(IChess item, int rank, int file)
    {
        if (_tiles[rank, file] is not null)
            throw new InvalidOperationException(
                $"New location is [{rank}, {file}]" +
                $"which is already occupied by another chess.");

        _tiles[rank, file] = item;

        return this;
    }

    public IChessBoard Remove(int rank, int file)
    {
        _tiles[rank, file] = null;

        return this;
    }

    public void Clear() => _tiles = default;
}

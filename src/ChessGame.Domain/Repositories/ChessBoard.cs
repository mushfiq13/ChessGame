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

    IChessBoard IChessBoard.Add(in IChess item)
    {
        _tiles[item.Rank, item.File] = item;

        return this;
    }

    public IChessBoard Add(in IChess item, int rank, int file)
    {
        _tiles[rank, file] = item;

        return this;
    }

    IChessBoard IChessBoard.Remove(int rank, int file)
    {
        _tiles[rank, file] = null;

        return this;
    }

    public void Clear() => _tiles = default;
}

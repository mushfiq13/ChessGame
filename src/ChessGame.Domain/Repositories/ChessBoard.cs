namespace ChessGame.Domain;

internal class ChessBoard : IChessBoard
{
    IChess[,] _tiles;

    public IChess[,] Tiles => _tiles;

    public ChessBoard()
        => _tiles = new IChess[ChessConstants.RANKS, ChessConstants.FILES];

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
            Put(value, rank, file);
        }
    }

    public IChessBoard Add(params IChess[] item)
    {
        foreach (var chess in item)
        {
            if (_tiles[chess.Rank, chess.File] is not null)
                throw new InvalidOperationException(
                    $"Chess location is [{chess.Rank}, {chess.File}]" +
                    $"which is already occupied by another chess.");

            _tiles[chess.Rank, chess.File] = chess;
        }

        return this;
    }

    public IChessBoard Put(IChess item, int rank, int file)
    {
        if (item?.Color == _tiles[rank, file]?.Color)
            throw new InvalidOperationException(
                $"New location is [{rank}, {file}]" +
                $"which is already occupied by same type of chess.");

        _tiles[rank, file] = item;

        return this;
    }

    public void Remove(int rank, int file)
        => _tiles[rank, file] = null;

    public void Clear()
        => _tiles = new IChess[ChessConstants.RANKS, ChessConstants.FILES];
}

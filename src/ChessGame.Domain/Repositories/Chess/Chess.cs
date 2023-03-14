namespace ChessGame.Domain;

internal abstract class Chess : IChess
{
    protected I2DChessValidator _chessValidator = ChessValidator.GetChessValidator();

    public int Rank { get; private set; }
    public int File { get; private set; }
    public ChessColor Color { get; }
    public string Unicode { get; }

    public Chess(ChessColor color, string unicode, int rank, int file)
    {
        if (_chessValidator.Inbounds(rank, file) == false
            || unicode is null
            || unicode.Trim() == string.Empty)
            throw new InvalidDataException();

        Rank = rank;
        File = file;
        Color = color;
        Unicode = unicode;
    }

    public void Put(int rank, int file)
    {
        if (_chessValidator.Inbounds(rank, file) == false)
            throw new InvalidDataException();

        Rank = rank;
        File = file;
    }

    public void Kill()
    {
        Rank = -1;
        File = -1;
    }

    public abstract bool CanMove(IChess[,] tiles, (int rank, int file) targetTile);
}

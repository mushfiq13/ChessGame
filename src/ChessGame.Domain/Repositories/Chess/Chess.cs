namespace ChessGame.Domain;

public abstract class Chess : IChess
{
    public int Rank { get; private set; }
    public int File { get; private set; }
    public ChessColor Color { get; }
    public string Unicode { get; }

    public Chess(ChessColor color, string unicode, int rank, int file)
    {

        if (ChessPathValidator.Inbounds(rank, file) == false
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
        if (ChessPathValidator.Inbounds(rank, file) == false)
            throw new InvalidDataException();

        Rank = rank;
        File = file;
    }

    public void Kill()
    {
        Rank = -1;
        File = -1;
    }

    public abstract bool IsMoveable(IChessCore[,] tiles, (int rank, int file) targetTile);
}

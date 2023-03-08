namespace ChessGame.Domain;

public abstract class Chess : IChess
{
    public int Rank { get; private set; }
    public int File { get; private set; }
    public ChessColor Color { get; }
    public string Unicode { get; }
    public bool IsKilled
    {
        get
        {
            return ChessQuery.Inbounds(Rank, File) is false;
        }
    }

    public Chess(ChessColor color, string unicode, int rank, int file)
    {
        Rank = rank;
        File = file;
        Color = color;
        Unicode = unicode;
    }

    public void Set(int rank, int file)
    {
        Rank = rank;
        File = file;
    }

    public void Kill()
    {
        Rank = -1;
        File = -1;
    }

    public abstract bool IsMoveable(in IChessCore[,] tiles, int targetRank, int targetFile);
}

namespace ChessGame.Domain;

public abstract class Chess : IChess
{
    public int Rank { get; private set; }
    public int File { get; private set; }
    public ChessColor Color { get; }
    public string Unicode { get; }
    public bool IsAlive
    {
        get
        {
            return ChessQuery.IsRankAndFileValid(Rank, File);
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

    public abstract bool IsMoveable(in IChessCore[,] tiles, int targetRank, int targetFile);
}

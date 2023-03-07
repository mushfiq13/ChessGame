namespace ChessGame.Domain;

public abstract class Chess : IChess
{
    public bool IsDead { get; private set; } = false;
    public int Rank { get; private set; }
    public int File { get; private set; }
    public ChessColor Color { get; }
    public string Unicode { get; }

    public Chess(ChessColor color, string unicode, int rank, int file)
    {
        Rank = rank;
        File = file;
        Color = color;
        Unicode = unicode;
    }

    public void Kill()
    {
        IsDead = true;
        Rank = -1;
        File = -1;
    }

    public void Move(int targetRank, int targetFile)
    {
        Rank = targetRank;
        File = targetFile;
    }

    public abstract bool IsMoveable(in IChessBase[,] tiles, int targetRank, int targetFile);
}

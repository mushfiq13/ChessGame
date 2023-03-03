namespace ChessGame.Domain;

public abstract class ChessPiece : IChessPiece
{
    bool _isAlive = true;

    public abstract ChessPieceColor Color { get; }
    public abstract string Unicode { get; }
    public abstract (int Rank, int File) Position { get; set; }
    public bool IsAlive
    {
        get => _isAlive;
        set
        {
            if (value == false)
                _isAlive = value;
        }
    }

    public abstract bool IsDestinationTileValid(int destRank, int destFile);
}

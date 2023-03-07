namespace ChessGame.Domain;

public interface IChessCore
{
    ChessColor Color { get; }
    string Unicode { get; }
    int Rank { get; }
    int File { get; }
}

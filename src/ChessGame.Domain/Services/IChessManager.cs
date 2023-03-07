namespace ChessGame.Domain;

public interface IChessManager : IChessBoard, IChessValidator
{
    void Add(in IChessCore item);
    void Set(in IChessCore item, int targetRank, int targetFile);
    void Remove(int rank, int file);
}

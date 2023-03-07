namespace ChessGame.Domain;

public interface IChessValidator
{
    bool Validate(IChessCore item);
}

namespace ChessGame.Domain;

public interface IChessValidator
{
    bool Validate(IChessBase chess);
}

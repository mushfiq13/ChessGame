using ChessGame.Domain;

namespace ChessGame.Application;

public class ChessRepository : IChessRepositoryManager
{
    public IChessPiece[,] Tiles { get; private set; }
    public (IChessPlayer WhiteChessPlayer, IChessPlayer BlackChessPlayer) Players { get; }
    public IChessPlayer CurrentPlayer { get; private set; }

    public ChessRepository()
    {
        Tiles = Factory.CreateChessBoard();
        Players = (Factory.CreateWhiteChessPlayer(), Factory.CreateBlackChessPlayer());
        CurrentPlayer = Players.WhiteChessPlayer;

        BoardInitializer.InitializeTiles(Tiles, Players);
    }

    public void MovePiece(IChessPiece piece, int targetRank, int targetFile)
    {
        Tiles[piece.Position.Rank, piece.Position.File] = null;
        Tiles[targetRank, targetFile] = piece;
    }

    public void RemovePiece(int rank, int file)
       => Tiles[rank, file] = null;

    public void TogglePlayer()
        => CurrentPlayer = CurrentPlayer.King.Color == ChessPieceColor.White
            ? Players.BlackChessPlayer : Players.WhiteChessPlayer;
}

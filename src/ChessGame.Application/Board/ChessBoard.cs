using ChessGame.Domain;

namespace ChessGame.Application;

public partial class ChessBoard : IChessBoard
{
    public IChessPiece[,] Tiles { get; private set; }
    public (IChessPlayer WhitePlayer, IChessPlayer BlackPlayer) Players { get; }
    public IChessPlayer ActivePlayer { get; set; }

    public ChessBoard()
    {
        Players = (new WhiteChessPlayer(), new BlackChessPlayer());
        Tiles = new IChessPiece[ChessConstants.RANKS, ChessConstants.FILES];

        InitializeTiles();

        ActivePlayer = Players.WhitePlayer;
    }
}

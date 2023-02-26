namespace ChessLib;

public partial class ChessBoard
{
    public static int Files { get; } = 8;
    public static int Ranks { get; } = 8;
    public static int TileWidth { get; } = 5;
    public IChessPiece[,]? Tiles { get; private set; }
    public (IChessPlayer WhiteOpponent, IChessPlayer BlackOpponent) Players { get; private set; }

    public ChessBoard()
    {
        Players = (new WhiteChessOpponent(), new BlackChessOpponent());
        Tiles = new IChessPiece[Files, Ranks];

        InitializeTiles();
    }
}

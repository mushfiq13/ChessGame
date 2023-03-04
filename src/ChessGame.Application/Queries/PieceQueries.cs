using ChessGame.Domain;

namespace ChessGame.Application;

internal class PieceQueries : IPieceQueries
{
    private readonly IChessPiece[,] _tiles;

    public PieceQueries(IChessPiece[,] tiles)
    {
        _tiles = tiles;
    }

    public bool IsPieceMoveable(IChessPiece piece, int targetRank, int targetFile)
        => piece.CanMove(_tiles, targetRank, targetFile);

    public bool IsOpponentsPiece(IChessPiece curPiece, int targetRank, int targetFile)
         => _tiles[targetRank, targetFile] is not null
             && curPiece.Color != _tiles[targetRank, targetFile].Color;

    public bool IsPlayersChoiceValid(int curRank, int curFile, int targetRank, int targetFile)
        => _tiles[curRank, curFile]?.Color != _tiles[targetRank, targetFile]?.Color;
}

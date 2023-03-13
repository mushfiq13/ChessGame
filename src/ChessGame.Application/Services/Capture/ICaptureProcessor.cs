using ChessGame.Domain;

namespace ChessGame.Application;

internal interface ICaptureProcessor
{
    (IChess sourceChess, (int rank, int file) targetTile) Process(ChessColor movingColor);
}
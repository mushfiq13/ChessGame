using ChessGame.Domain;

namespace ChessGame.Application;

internal class PieceCommands : IPieceCommands
{
    private readonly IChessRepositoryManager _repositoryManager;

    public PieceCommands(IChessRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    public void MovePiece(IChessPiece piece, int targetRank, int targetFile)
    {
        _repositoryManager.MovePiece(piece, targetRank, targetFile);
        piece.Move(targetRank, targetFile);
    }

    public void KillPiece(IChessPiece piece)
    {
        _repositoryManager.RemovePiece(piece.Position.Rank, piece.Position.File);
        piece.Kill();
    }
}

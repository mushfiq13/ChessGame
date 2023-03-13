namespace ChessGame.Domain;

internal class ChessFactory : IChessFactory
{
    public IChess[] CreateKing()
    {
        return new IChess[] {
            new King(ChessColor.White, "\u2654", 0, 4),
            new King(ChessColor.Black, "\u265A", 7, 4)
        };
    }

    public IChess[] CreateQueen()
    {
        return new IChess[] {
            new Queen(ChessColor.White, "\u2655", 0, 3),
            new Queen(ChessColor.Black, "\u265B", 7, 3)
        };
    }

    public IChess[] CreateRook()
    {
        return new IChess[] {
            new Rook(ChessColor.White, "\u2656", 0, 0),
            new Rook(ChessColor.White, "\u2656", 0, 7),
            new Rook(ChessColor.Black, "\u265C", 7, 0),
            new Rook(ChessColor.Black, "\u265C", 7, 7)
        };
    }

    public IChess[] CreateBishop()
    {
        return new IChess[] {
            new Bishop(ChessColor.White, "\u2657", 0, 2),
            new Bishop(ChessColor.White, "\u2657", 0, 5),
            new Bishop(ChessColor.Black, "\u265D", 7, 2),
            new Bishop(ChessColor.Black, "\u265D", 7, 5)
        };
    }

    public IChess[] CreateKnight()
    {
        return new IChess[] {
            new Knight(ChessColor.White, "\u2658", 0, 1),
            new Knight(ChessColor.White, "\u2658", 0, 6),
            new Knight(ChessColor.Black, "\u265E", 7, 1),
            new Knight(ChessColor.Black, "\u265E", 7, 6)
        };
    }

    public IChess[] CreatePawn()
    {
        var pawn = new IChess[8 * 2];

        for (var i = 0; i < ChessConstants.FILES; ++i)
        {
            pawn[i] = new Pawn(ChessColor.White, "\u2659", 1, i);
            pawn[i + ChessConstants.FILES] = new Pawn(ChessColor.Black, "\u265F", 6, i);
        }

        return pawn;
    }
}

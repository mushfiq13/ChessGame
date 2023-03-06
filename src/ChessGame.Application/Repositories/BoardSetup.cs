using ChessGame.Domain;

namespace ChessGame.Application;

public partial class ChessManager
{
    public void Setup()
    {
        Board.Add(Factory.CreateKing(ChessColor.White, "\u2654", 0, 4));
        Board.Add(Factory.CreateKing(ChessColor.Black, "\u265A", 7, 4));

        Board.Add(Factory.CreateQueen(ChessColor.White, "\u2655", 0, 3));
        Board.Add(Factory.CreateQueen(ChessColor.Black, "\u265B", 7, 3));

        Board.Add(Factory.CreateBishop(ChessColor.White, "\u2657", 0, 2));
        Board.Add(Factory.CreateBishop(ChessColor.White, "\u2657", 0, 5));
        Board.Add(Factory.CreateBishop(ChessColor.Black, "\u265D", 7, 2));
        Board.Add(Factory.CreateBishop(ChessColor.Black, "\u265D", 7, 5));

        Board.Add(Factory.CreateRook(ChessColor.White, "\u2656", 0, 0));
        Board.Add(Factory.CreateRook(ChessColor.White, "\u2656", 0, 7));
        Board.Add(Factory.CreateRook(ChessColor.Black, "\u265C", 7, 7));
        Board.Add(Factory.CreateRook(ChessColor.Black, "\u265C", 7, 0));

        Board.Add(Factory.CreateKnight(ChessColor.White, "\u2658", 0, 1));
        Board.Add(Factory.CreateKnight(ChessColor.White, "\u2658", 0, 6));
        Board.Add(Factory.CreateKnight(ChessColor.Black, "\u265E", 7, 1));
        Board.Add(Factory.CreateKnight(ChessColor.Black, "\u265E", 7, 6));

        for (var i = 0; i < 8; ++i)
            Board.Add(Factory.CreatePawn(ChessColor.White, "\u2659", 1, i));

        for (var i = 0; i < 8; ++i)
            Board.Add(Factory.CreatePawn(ChessColor.Black, "\u265F", 6, i));
    }
}

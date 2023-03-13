using ChessGame.API;
using ChessGame.Application;

Console.OutputEncoding = System.Text.Encoding.UTF8;

IChessApplication app = Factory.CreateChessApplication();

app.Run();
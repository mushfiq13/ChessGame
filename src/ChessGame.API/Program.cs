using ChessGame.API;
using ChessGame.Application;

Console.OutputEncoding = System.Text.Encoding.UTF8;

IChessApplicationServiceProvider app = Factory.CreateChessApplication();

app.Run();
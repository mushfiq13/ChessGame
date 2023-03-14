using ChessGame.API;
using ChessGame.Application;

Console.OutputEncoding = System.Text.Encoding.UTF8;

IApplicationServiceProvider app = Factory.CreateChessApplication();

app.Run();
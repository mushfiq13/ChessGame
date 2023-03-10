using ChessGame.API;
using ChessGame.Application;

Console.OutputEncoding = System.Text.Encoding.UTF8;

IGameManager manager = Factory.CreateGameManager();

manager.Play();
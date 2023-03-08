using ChessGame.Application;

Console.OutputEncoding = System.Text.Encoding.UTF8;

using IGameManager manager = new GameManager();

manager.Play();
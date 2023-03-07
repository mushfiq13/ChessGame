namespace ChessGame.ConsoleUI
{
    internal interface IConsoleIOMessager
    {
        void InvalidInputMessage();
        void Message(string message);
    }
}
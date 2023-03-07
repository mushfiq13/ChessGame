namespace ChessGame.ConsoleUI;

public class ConsoleInput : IConsoleInput
{
    private ConsoleIOMessager _iOMessager = new();

    public (int Rank, int File) ReadTilePosition(string selectionMessage)
    {
        BreakLine();
        _iOMessager.Message(selectionMessage);

        _iOMessager.Message("Select rank and press enter:");
        var rank = DigitReader();

        _iOMessager.Message("Select file and press enter:");
        var file = DigitReader();

        return (rank, file);
    }

    private int DigitReader()
    {
        var result = -1;

        while (result is -1)
        {
            var input = Console.ReadLine();
            var digit = input?.ElementAtOrDefault(0);

            if (input.Length > 1 || (digit < '0' || digit > '9'))
                _iOMessager.InvalidInputMessage();
            else
                result = (char)digit - '0';
        };

        return result;
    }

    private void BreakLine() => Console.WriteLine();
}

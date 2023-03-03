namespace ChessGame.Presentation;

internal class ConsoleIOMessager
{
    public void RequestToSelectChess()
    {
        Console.WriteLine("Please select from which cell you want to move a chess...");
    }

    public int RowColReader(string rowOrCol)
    {

        var result = -1;

        while (result == -1)
        {
            Console.Write($"Select {rowOrCol} and press enter: ");

            var input = Console.ReadLine();
            var digit = input.ElementAtOrDefault(0);

            if (input.Length > 1 || (digit < '0' || digit > '9'))
                Console.WriteLine("Invalid Input! Please select the right one.");
            else
                result = digit - '0';
        };

        return result;
    }

    public void RequestToMoveChess()
    {
        Console.WriteLine("Please select in which cell you want to move selected chess...");
    }
}

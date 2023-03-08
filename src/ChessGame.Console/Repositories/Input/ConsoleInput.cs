namespace ChessGame.ConsoleUI;

public class ConsoleInput : IConsoleInput
{
    public (int Rank, int File) SelectMoveableChess()
    {
        Console.WriteLine();
        Console.WriteLine("Select rank and file with this format : [0 0] and press enter:");

        return Reader();
    }

    private (int, int) Reader()
    {
        bool Inbound(int rank, int file)
            => rank >= 0 && file >= 0
                && rank < 8 && file < 8;

        while (true)
        {
            var input = Console.ReadLine();

            if (input.Length == 3
                && char.IsDigit(input[0])
                && input[1] == ' '
                && char.IsDigit(input[2])
                && Inbound(input[0], input[2]) is false)
                return (input[0] - '0', input[2] - '0');

            Console.WriteLine("Inavlid input!");
        };
    }
}

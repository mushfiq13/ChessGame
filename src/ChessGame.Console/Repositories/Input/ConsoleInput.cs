namespace ChessGame.ConsoleUI;

public class ConsoleInput : IConsoleInput
{
    IConsoleMessager _messager = Factory.CreateConsoleMessager();

    public (int Rank, int File) SelectMoveableChess()
    {
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
            var parts = input.Where(c => c != ' ').ToArray();

            if (parts.Length == 2 && char.IsDigit(parts[0]) && char.IsDigit(parts[1]))
            {
                var rank = parts[0] - '0';
                var file = parts[1] - '0';

                if (Inbound(rank, file))
                    return (rank, file);

                _messager.IndexOutOfBound();
            }
            else _messager.InvalidDataCapture();
        };
    }
}

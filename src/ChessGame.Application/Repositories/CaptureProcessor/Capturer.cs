namespace ChessGame.Application;

internal class Capturer : ICapturer
{
    public (int, int) Capture()
    {
        Singleton.ConsoleMessages.WriteMessage("Enter rank and file ->");

        var input = Singleton.ConsoleInput.CaptureTile() as string;
        var parts = input?.Where(ch => ch != ' ')?.ToArray();

        if (parts?.Length == 2 && char.IsDigit(parts[0]) && char.IsDigit(parts[1]))
            return (parts[0] - '0', parts[1] - '0');

        return (-1, -1);
    }
}

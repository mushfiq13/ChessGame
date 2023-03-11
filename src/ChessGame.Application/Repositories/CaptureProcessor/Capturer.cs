namespace ChessGame.Application;

internal class Capturer : ICapturer
{
    public (int, int) Capture()
    {
        try
        {
            Singleton.Logger.Write("Enter rank: ");
            var rank = ReadAndExtractDigit();

            Singleton.Logger.Write("Enter file: ");
            var file = ReadAndExtractDigit();

            return (rank, file);
        }
        catch
        {
            Singleton.Logger.LogError("Could not get any valid data!");
        }

        return (-1, -1);
    }

    private int ReadAndExtractDigit()
    {
        var input = Singleton.IO.Input.Reader();
        var charArray = input?.Trim().ToCharArray();

        if (charArray.Length == 1)
            return charArray[0] - '0';

        throw new InvalidDataException();
    }
}

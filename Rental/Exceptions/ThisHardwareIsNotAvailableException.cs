namespace Rental.Exceptions;

public class ThisHardwareIsNotAvailableException(Hardware hardware) : Exception(BuildMessage(hardware))
{
    private static string BuildMessage(Hardware hardware)
    {
        string str = "This hardware current status is: " + hardware.Status;
        int messageLength = str.Length;

        return
            new string('-', messageLength) + "\n" +
            str + "\n" +
            new string('-', messageLength);
    }
}
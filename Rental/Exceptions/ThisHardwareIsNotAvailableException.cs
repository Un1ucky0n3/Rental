namespace Rental.Exceptions;

public class ThisHardwareIsNotAvailableException(Hardware hardware) : Exception(BuildMessage(hardware))
{
    private static string BuildMessage(Hardware hardware)
    {
        return "This hardware current status is: " + hardware.Status;
    }
}
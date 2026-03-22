using Rental.Users;

namespace Rental.Exceptions;

public class RentalNotFoundException(Hardware hardware, User user) : Exception(BuildMessage(hardware, user))
{
    private static string BuildMessage(Hardware hardware, User user)
    {
        string str = "Rental not found for user: " + user.Name + " hardware:" + hardware.Name;
        int messageLength = str.Length;

        return
            new string('-', messageLength) + "\n" +
            str + "\n" +
            new string('-', messageLength);
    }
}
using Rental.Users;

namespace Rental.Exceptions;

public class UserAlreadyRentedOutThisHardwareException(User user, Hardware hardware)
    : Exception(BuildMessage(user, hardware))
{
    private static string BuildMessage(User user, Hardware hardware)
    {
        string message = "User " + user.Name + " " + user.Surname +
                         " already rented out this hardware: " + hardware.Name;

        int messageLength = message.Length;

        return new string('-', messageLength) + "\n" +
               message + "\n" +
               new string('-', messageLength);
    }
}
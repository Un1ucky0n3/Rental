using Rental.Users;

namespace Rental.Exceptions;

public class UserRentedOutTooMuchHardwareException(User user) : Exception(BuildMessage(user))
{
    private static string BuildMessage(User user)
    {
        string message = "User " + user.Name + " " + user.Surname +
                         " already rented too much hardware";

        int messageLength = message.Length;

        return new string('-', messageLength) + "\n" +
               message + "\n" +
               new string('-', messageLength);
    }
}
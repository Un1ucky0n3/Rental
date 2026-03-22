using Rental.Users;

namespace Rental.Exceptions;

public class UserRentedOutTooMuchHardwareException(User user) : Exception(BuildMessage(user))
{
    private static string BuildMessage(User user)
    {
        return "User " + user.Name + " " + user.Surname +
                         " already rented too much hardware";
    }
}
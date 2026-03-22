using Rental.Users;

namespace Rental.Exceptions;

public class UserAlreadyRentedOutThisHardwareException(User user, Hardware hardware)
    : Exception(BuildMessage(user, hardware))
{
    private static string BuildMessage(User user, Hardware hardware)
    {
        return "User " + user.Name + " " + user.Surname +
                         " already rented out this hardware: " + hardware.Name;
    }
}
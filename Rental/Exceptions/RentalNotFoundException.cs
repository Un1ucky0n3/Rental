using Rental.Users;

namespace Rental.Exceptions;

public class RentalNotFoundException(Hardware hardware, User user) : Exception(BuildMessage(hardware, user))
{
    private static string BuildMessage(Hardware hardware, User user)
    {
        return "Rental not found for user: " + user.Name + " hardware:" + hardware.Name;
    }
}
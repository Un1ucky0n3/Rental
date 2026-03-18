using Rental.Users;

namespace Rental.Logic;

public class Service
{
    private List<Hardware> Hardwares { get; set; } = new();
    private List<User> Users { get; set; } = new();
    private List<Rental> Rentals { get; set; } = new();
}
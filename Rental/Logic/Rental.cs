using Rental.Users;

namespace Rental.Logic;

public class Rental
{
    public Hardware Hardware { get; set; }
    public User User { get; set; }
    public String RentDate { get; set; }
    public int HowLong { get; set; } //days
    public String ReturnDate { get; set; }
    public String ActualReturnDate { get; set; }
    public bool IsItOverDue { get; set; }
    public double Penalty { get; set; }
    public Rental(Hardware hardware, User user, String rentDate, int howLong, String returnDate)
    {
        this.Hardware = hardware;
        this.User = user;
        this.RentDate = rentDate;
        this.HowLong = howLong;
        this.ReturnDate = returnDate;
    }
}
using Rental.Users;

namespace Rental.Logic;

public class Rental
{
    private Hardware Hardware { get; set; }
    private User User { get; set; }
    private String RentDate { get; set; }
    private int HowLong { get; set; } //days
    private String ReturnDate { get; set; }
    private String ActualReturnDate { get; set; }
    private bool IsItOverDue { get; set; }
    private double Penalty { get; set; }
    public Rental(Hardware hardware, User user, String rentDate, int howLong, String returnDate)
    {
        this.Hardware = hardware;
        this.User = user;
        this.RentDate = rentDate;
        this.HowLong = howLong;
        this.ReturnDate = returnDate;
    }
}
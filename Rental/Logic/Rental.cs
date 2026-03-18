using Rental.Users;

namespace Rental.Logic;

public class Rental
{
    private Sprzet sprzet { get; set; }
    private User user { get; set; }
    private String rentDate { get; set; }
    private int howLong { get; set; } //days
    private String returnDate { get; set; }
    private String actualReturnDate { get; set; }
    private bool isItOverDue { get; set; }
    private double penalty { get; set; }

    public Rental(Sprzet sprzet, User user, String rentDate, int howLong, String returnDate)
    {
        this.sprzet = sprzet;
        this.user = user;
        this.rentDate = rentDate;
        this.howLong = howLong;
        this.returnDate = returnDate;
    }
}
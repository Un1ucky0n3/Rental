using Rental.Users;

namespace Rental.Logic;

public class Rental
{
    private Sprzet sprzet;
    private User user;
    private String rentDate;
    private int howLong; //days
    private String returnDate;
    private String actualReturnDate;
    private bool isItOverDue;
    private double penalty;

    public Rental(Sprzet sprzet, User user, String rentDate, int howLong, String returnDate)
    {
        this.sprzet = sprzet;
        this.user = user;
        this.rentDate = rentDate;
        this.howLong = howLong;
        this.returnDate = returnDate;
    }

    public Sprzet getSprzet()
    {
        return sprzet;
    }
    public void setSprzet(Sprzet sprzet)
    {
        this.sprzet = sprzet;
    }

    public User getUser()
    {
        return user;
    }
    public void setUser(User user)
    {
        this.user = user;
    }

    public String getRentDate()
    {
        return rentDate;
    }
    public void setRentDate(String rentDate)
    {
        this.rentDate = rentDate;
    }

    public int getHowLong()
    {
        return howLong;
    }
    public void setHowLong(int howLong)
    {
        this.howLong = howLong;
    }

    public String getReturnDate()
    {
        return returnDate;
    }
    public void setReturnDate(String returnDate)
    {
        this.returnDate = returnDate;
    }

    public String getActualReturnDate()
    {
        return actualReturnDate;
    }
    public void setActualReturnDate(String actualReturnDate)
    {
        this.actualReturnDate = actualReturnDate;
    }
    
    public bool getIsItOverDue()
    {
        return isItOverDue;
    }
    public void setIsItOverDue(bool isItOverDue)
    {
        this.isItOverDue = isItOverDue;
    }

    public double getPenalty()
    {
        return penalty;
    }
    public void setPenalty(double penalty)
    {
        this.penalty = penalty;
    }
    
}
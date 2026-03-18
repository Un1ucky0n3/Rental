namespace Rental;

public abstract class Sprzet
{
    private int id;
    private bool rented;
    private int idRental;
    private String name;
    private double price;

    public Sprzet(int id,  string name, double price)
    {
        this.idRental = id;
        this.rented = false;
        this.name = name;
        this.price = price;
    }

    public int getId()
    {
        return id;
    }
    public void setId(int id)
    {
        this.id = id;
    }
    public bool getRented()
    {
        return rented;
    }
    public void setRented(bool rented)
    {
        this.rented = rented;
    }
    public int getIdRental()
    {
        return idRental;
    }
    public void setIdRental(int idRental)
    {
        this.idRental = idRental;
    }
}
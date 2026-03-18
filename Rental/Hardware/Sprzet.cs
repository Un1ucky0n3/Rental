namespace Rental;

public abstract class Sprzet
{
    private int id;
    private bool rented;
    private String name;
    private double price;

    public Sprzet(int id,  string name, double price)
    {
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
}
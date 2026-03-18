namespace Rental;

public abstract class Sprzet
{
    private int id { set; get; }
    private STATUS status { set; get; }
    private String name { set; get; }
    private double price { set; get; }

    public Sprzet(int id, string name, double price)
    {
        this.status = STATUS.UNAVAILABLE;
        this.name = name;
        this.price = price;
    }
}
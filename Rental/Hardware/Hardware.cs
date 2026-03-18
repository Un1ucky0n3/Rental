namespace Rental;

public abstract class Hardware
{
    public int Id { set; get; }
    public STATUS Status { set; get; }
    public String Name { set; get; }
    public double Price { set; get; }

    public Hardware(int id, string name, double price)
    {
        this.Id = id;
        this.Status = STATUS.AVAILABLE;
        this.Name = name;
        this.Price = price;
    }
}
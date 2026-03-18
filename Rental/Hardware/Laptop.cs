namespace Rental;

public class Laptop : Sprzet
{
    private string processor { get; set; }
    private string graphicsCard { get; set; }
    private int ram { get; set; }        // GB
    private int storage { get; set; }    // GB
    private double screenSize { get; set; } // inches

    public Laptop(int id, string name, double price,
        string processor, string graphicsCard,
        int ram, int storage, double screenSize)
        : base(id, name, price)
    {
        this.processor = processor;
        this.graphicsCard = graphicsCard;
        this.ram = ram;
        this.storage = storage;
        this.screenSize = screenSize;
    }
}
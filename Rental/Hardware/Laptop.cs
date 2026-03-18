namespace Rental;

public class Laptop : Sprzet
{
    private string processor;
    private string graphicsCard;
    private int ram;        // GB
    private int storage;    // GB
    private double screenSize; // inches

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

    public string GetProcessor()
    {
        return processor;
    }

    public void SetProcessor(string processor)
    {
        this.processor = processor;
    }

    public string GetGraphicsCard()
    {
        return graphicsCard;
    }

    public void SetGraphicsCard(string graphicsCard)
    {
        this.graphicsCard = graphicsCard;
    }

    public int GetRam()
    {
        return ram;
    }

    public void SetRam(int ram)
    {
        this.ram = ram;
    }

    public int GetStorage()
    {
        return storage;
    }

    public void SetStorage(int storage)
    {
        this.storage = storage;
    }

    public double GetScreenSize()
    {
        return screenSize;
    }

    public void SetScreenSize(double screenSize)
    {
        this.screenSize = screenSize;
    }
}
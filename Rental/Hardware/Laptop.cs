using Rental;

public class Laptop : Hardware
{
    public string? Processor { get; private set; }
    public string? GraphicsCard { get; private set; }
    public int RAM { get; private set; }
    public int Storage { get; private set; }
    public double ScreenSize { get; private set; }

    public Laptop(int id, string name, double price,
        string? processor = null,
        string? graphicsCard = null,
        int ram = 0,
        int storage = 0,
        double screenSize = 0)
        : base(id, name, price)
    {
        Processor = processor;
        GraphicsCard = graphicsCard;
        RAM = ram;
        Storage = storage;
        ScreenSize = screenSize;
    }
}
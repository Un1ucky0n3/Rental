namespace Rental;

public class LaptopBuilder
{
    private int _id;
    private string _name = "Unknown Laptop";
    private double _price = 0;
    private string? _processor;
    private string? _graphicsCard;
    private int _ram;
    private int _storage;
    private double _screenSize;

    public LaptopBuilder WithId(int id) { _id = id; return this; }
    public LaptopBuilder WithName(string name) { _name = name; return this; }
    public LaptopBuilder WithPrice(double price) { _price = price; return this; }
    public LaptopBuilder WithProcessor(string processor) { _processor = processor; return this; }
    public LaptopBuilder WithGraphicsCard(string gpu) { _graphicsCard = gpu; return this; }
    public LaptopBuilder WithRAM(int ram) { _ram = ram; return this; }
    public LaptopBuilder WithStorage(int storage) { _storage = storage; return this; }
    public LaptopBuilder WithScreenSize(double size) { _screenSize = size; return this; }

    public Laptop Build() => new Laptop(_id, _name, _price, _processor, _graphicsCard, _ram, _storage, _screenSize);
}
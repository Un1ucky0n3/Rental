namespace Rental;
public class ProjectorBuilder
{
    private int _id;
    private string _name = "Unknown Projector";
    private double _price = 0;
    private string? _resolution;
    private int _brightness;
    private int _contrastRatio;

    public ProjectorBuilder WithId(int id) { _id = id; return this; }
    public ProjectorBuilder WithName(string name) { _name = name; return this; }
    public ProjectorBuilder WithPrice(double price) { _price = price; return this; }
    public ProjectorBuilder WithResolution(string resolution) { _resolution = resolution; return this; }
    public ProjectorBuilder WithBrightness(int brightness) { _brightness = brightness; return this; }
    public ProjectorBuilder WithContrastRatio(int contrast) { _contrastRatio = contrast; return this; }

    public Projector Build() => new Projector(_id, _name, _price, _resolution, _brightness, _contrastRatio);
}
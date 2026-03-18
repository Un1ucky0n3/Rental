namespace Rental;

public class Projector : Hardware
{
    public string? Resolution { get; private set; }
    public int Brightness { get; private set; } // lumens
    public int ContrastRatio { get; private set; }

    public Projector(int id, string name, double price,
        string? resolution = null,
        int brightness = 0,
        int contrastRatio = 0)
        : base(id, name, price)
    {
        Resolution = resolution;
        Brightness = brightness;
        ContrastRatio = contrastRatio;
    }
}
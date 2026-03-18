namespace Rental;

public class Projector : Sprzet
{
    private string resolution { get; set; }
    private int brightness { get; set; } // lumens
    private int contrastRatio { get; set; }
    private double weight { get; set; } // kg
    private bool hasHdmi { get; set; }

    public Projector(int id, string name, double price,
        string resolution, int brightness,
        int contrastRatio, double weight, bool hasHdmi)
        : base(id, name, price)
    {
        this.resolution = resolution;
        this.brightness = brightness;
        this.contrastRatio = contrastRatio;
        this.weight = weight;
        this.hasHdmi = hasHdmi;
    }
}
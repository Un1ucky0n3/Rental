namespace Rental;

public class Projector : Sprzet
{
    private string resolution;
    private int brightness; // lumens
    private int contrastRatio;
    private double weight; // kg
    private bool hasHdmi;

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

    public string GetResolution()
    {
        return resolution;
    }
    public void SetResolution(string resolution)
    {
        this.resolution = resolution;
    }
    public int GetBrightness()
    {
        return brightness;
    }
    public void SetBrightness(int brightness)
    {
        this.brightness = brightness;
    }
    public int GetContrastRatio()
    {
        return contrastRatio;
    }
    public void SetContrastRatio(int contrastRatio)
    {
        this.contrastRatio = contrastRatio;
    }
    public double GetWeight()
    {
        return weight;
    }
    public void SetWeight(double weight)
    {
        this.weight = weight;
    }
    public bool GetHasHdmi()
    {
        return hasHdmi;
    }
    public void SetHasHdmi(bool hasHdmi)
    {
        this.hasHdmi = hasHdmi;
    }
}
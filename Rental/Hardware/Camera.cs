namespace Rental;

public class Camera : Sprzet
{
    private double resolution { get; set; } // megapixels
    private string sensorType { get; set; }
    private bool hasVideo { get; set; }
    private double weight { get; set; } // grams
    private string lensMount { get; set; }

    public Camera(int id, string name, double price,
        double resolution, string sensorType,
        bool hasVideo, double weight, string lensMount)
        : base(id, name, price)
    {
        this.resolution = resolution;
        this.sensorType = sensorType;
        this.hasVideo = hasVideo;
        this.weight = weight;
        this.lensMount = lensMount;
    }
}
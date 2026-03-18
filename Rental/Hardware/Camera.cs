namespace Rental;

public class Camera : Hardware
{
    public double Resolution { get; private set; }  // Megapixels
    public string? SensorType { get; private set; }
    public string? LensMount { get; private set; }

    public Camera(int id, string name, double price,
        double resolution = 0,
        string? sensorType = null,
        string? lensMount = null)
        : base(id, name, price)
    {
        Resolution = resolution;
        SensorType = sensorType;
        LensMount = lensMount;
    }
}
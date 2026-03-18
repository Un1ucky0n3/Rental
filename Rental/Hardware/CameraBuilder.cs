namespace Rental;

public class CameraBuilder
{
    private int _id;
    private string _name = "Unknown Camera";
    private double _price = 0;
    private double _resolution;
    private string? _sensorType;
    private string? _lensMount;

    public CameraBuilder WithId(int id) { _id = id; return this; }
    public CameraBuilder WithName(string name) { _name = name; return this; }
    public CameraBuilder WithPrice(double price) { _price = price; return this; }
    public CameraBuilder WithResolution(double res) { _resolution = res; return this; }
    public CameraBuilder WithSensorType(string sensor) { _sensorType = sensor; return this; }
    public CameraBuilder WithLensMount(string lens) { _lensMount = lens; return this; }

    public Camera Build() => new Camera(_id, _name, _price, _resolution, _sensorType, _lensMount);
}
namespace Rental;

public class Camera : Sprzet
{
    private double resolution; // megapixels
    private string sensorType;
    private bool hasVideo;
    private double weight; // grams
    private string lensMount;

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

    public double GetResolution()
    {
        return resolution;
    }
    public void SetResolution(double resolution)
    {
        this.resolution = resolution;
    }
    public string GetSensorType()
    {
        return sensorType;
    }
    public void SetSensorType(string sensorType)
    {
        this.sensorType = sensorType;
    }
    public bool GetHasVideo()
    {
        return hasVideo;
    }
    public void SetHasVideo(bool hasVideo)
    {
        this.hasVideo = hasVideo;
    }
    public double GetWeight()
    {
        return weight;
    }
    public void SetWeight(double weight)
    {
        this.weight = weight;
    }
    public string GetLensMount()
    {
        return lensMount;
    }
    public void SetLensMount(string lensMount)
    {
        this.lensMount = lensMount;
    }
}
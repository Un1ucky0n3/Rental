using Rental;
using Rental.Logic;

class Program
{
    static void Main(string[] args)
    {
        Service service = new Service();
        
        service.AddHardware(new LaptopBuilder()
            .WithId(0)
            .WithName("Dell XPS 15")
            .WithPrice(1500)
            .WithProcessor("Intel i7")
            .WithGraphicsCard("RTX 3050")
            .WithRAM(16)
            .WithStorage(512)
            .WithScreenSize(15.6)
            .Build());

        service.AddHardware(new LaptopBuilder()
            .WithId(0)
            .WithName("MacBook Pro")
            .WithPrice(2500)
            .WithProcessor("M2")
            .WithRAM(16)
            .WithStorage(1024)
            .Build()); // partial specs okay
        
        service.AddHardware(new ProjectorBuilder()
            .WithId(0)
            .WithName("Epson X123")
            .WithPrice(800)
            .WithResolution("1080p")
            .WithBrightness(3000)
            .WithContrastRatio(10000)
            .Build());
        
        service.AddHardware(new CameraBuilder()
            .WithId(0)
            .WithName("Canon EOS R5")
            .WithPrice(3500)
            .WithResolution(45)
            .WithSensorType("Full Frame")
            .WithLensMount("RF")
            .Build());
        
        service.PrintAllHardware(STATUS.AVAILABLE);
    }
}
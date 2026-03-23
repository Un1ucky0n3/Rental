using Rental.Logic;
using Rental.UI;

class Program
{
    static void Main(string[] args)
    {
        Service service = new Service();
        UI ui = new UI(service);
        ui.Run();
    }
}
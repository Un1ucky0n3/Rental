using Rental.Users;

namespace Rental.Logic;

public class Service
{
    private List<Hardware> Hardwares { get; set; } = new();
    private List<User> Users { get; set; } = new();
    private List<Rental> Rentals { get; set; } = new();

    public void AddUser(String name, String surname, USR_TYPE type)
    {
        int id = 0;
        if(Users.Count != 0)
            id = Users.Max(u => u.Id) + 1;
        Users.Add(new User(id, name, surname, type));
    }
    public void AddHardware(Hardware hardware)
    {
        int id = 0;
        if(Hardwares.Count != 0)
            id = Hardwares.Max(h => h.Id) + 1;
        hardware.Id = id;
        Hardwares.Add(hardware);
    }
    public void PrintAllHardware()
    {
        Console.WriteLine($"{"ID",-5} {"Type",-10} {"Name",-20} {"Status",-15}");
        Console.WriteLine(new string('-', 50));

        foreach (Hardware h in Hardwares)
        {
            Console.WriteLine($"{h.Id,-5} {h.GetType().Name,-10} {h.Name,-20} {h.Status, -15}");
        }
        Console.WriteLine(new string('-', 50));
    }
    public void PrintAllHardware(STATUS status)
    {
        Console.WriteLine($"{"ID",-5} {"Type",-10} {"Name",-20} {"Status",-15}");
        Console.WriteLine(new string('-', 50));

        foreach (Hardware h in Hardwares)
        {
            if(h.Status == status)
                Console.WriteLine($"{h.Id,-5} {h.GetType().Name,-10} {h.Name,-20} {h.Status, -15}");
        }
        Console.WriteLine(new string('-', 50));
    }
    
}
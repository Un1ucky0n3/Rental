namespace Rental.Users;

using Rental;
using Rental.Logic;
using Rental.Users;
using Rental.UI;

public class ShowcaseProgram
{
    public static void demo()
    {
        Service service = new Service();
        UI ui = new UI(service);

        // ===== Punkt 11 =====
        var laptop = new LaptopBuilder()
            .WithName("Dell XPS 15")
            .WithPrice(1500)
            .WithProcessor("Intel i7")
            .Build();

        var projector = new ProjectorBuilder()
            .WithName("Epson X123")
            .WithPrice(800)
            .Build();

        service.AddHardware(laptop);
        service.AddHardware(projector);
        
        Console.Write(service.GenerateShowAllHardware());
        
        // ===== Punkt 12 =====
        service.AddUser("Jan", "Kowalski", USR_TYPE.STUDENT);
        service.AddUser("Anna", "Nowak", USR_TYPE.EMPLOYEE);
        var user1 = service.Users[0];
        var user2 = service.Users[1];

        // ===== Punkt 13 =====
        Console.WriteLine("\n=== RENTING LAPTOP TO USER1 ===");
        service.RentHardwareToUser(laptop, user1, 3);
        Console.WriteLine("\n=== USER1 RENTALS ===");
        service.PrintUserRentals(user1);

        // ===== Punkt 14 =====
        Console.WriteLine("\n=== RENT SAME LAPTOP AGAIN ===");
        try
        {
            service.RentHardwareToUser(laptop, user2);
        }catch (Exception e)
        {
            Console.WriteLine(new string('-', e.Message.Length));
            Console.WriteLine(e.Message);
            Console.WriteLine(new string('-', e.Message.Length));
        }

        // ===== Punkt 15 =====
        Console.WriteLine("\n=== RETURNING ON TIME ===");
        try{
            double penalty1 = service.ReturnHardwareAndCalculatePenalty(laptop, user1);
            Console.WriteLine($"Penalty: {penalty1} zł");
        }catch (Exception e)
        {
            Console.WriteLine(new string('-', e.Message.Length));
            Console.WriteLine(e.Message);
            Console.WriteLine(new string('-', e.Message.Length));
        }

        // ===== Punkt 16 =====
        Console.WriteLine("\n=== RENT AGAIN - OVERDUE TEST ===");
        try{
            service.RentHardwareToUser(projector, user1, -1);
            Console.WriteLine("\n=== OVERDUE RENTALS ===");
        }catch (Exception e)
        {
            Console.WriteLine(new string('-', e.Message.Length));
            Console.WriteLine(e.Message);
            Console.WriteLine(new string('-', e.Message.Length));
        }
        service.PrintOverdueRentals();

        Console.WriteLine("\n=== RETURNING LATE ===");
        try{
            double penalty2 = service.ReturnHardwareAndCalculatePenalty(projector, user1);
            Console.WriteLine($"Penalty: {penalty2} zł");
        }catch (Exception e)
        {
            Console.WriteLine(new string('-', e.Message.Length));
            Console.WriteLine(e.Message);
            Console.WriteLine(new string('-', e.Message.Length));
        }

        // ===== Punkt 17 =====
        Console.WriteLine("\n=== FINAL REPORT ===");
        Console.WriteLine(service.GenerateReport());
        Console.WriteLine("=== CLICK ENTER TO END DEMO SHOWCASE ===");
        Console.ReadLine();
    }
}
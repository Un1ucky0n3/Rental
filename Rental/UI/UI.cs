using Rental.Users;

namespace Rental.UI;

using Rental.Logic;
using Rental.Users;

public class UI
{
    private Service service;

    public UI(Service service)
    {
        this.service = service;
    }

    private void Show(string message)
    {
        Console.WriteLine(new string('-', message.Length));
        Console.WriteLine(message);
        Console.WriteLine(new string('-', message.Length));
    }

    // ===== USERS =====
    public void AddUser()
    {
        try
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Surname: ");
            string surname = Console.ReadLine();

            Console.Write("Type (0 = STUDENT, 1 = EMPLOYEE): ");
            USR_TYPE type = (USR_TYPE)int.Parse(Console.ReadLine());

            service.AddUser(name, surname, type);

            Show("User: "+name+" "+surname+" added successfully!");
        }
        catch (Exception e)
        {
            Show(e.Message);
        }
    }

    // ===== HARDWARE =====
    public void ShowAllHardware()
    {
        Console.Write("Filter (ENTER = show all, 0 = AVAILABLE, 1 = RENTED, 2 = BROKEN, 3 = UNAVAILABLE): ");
        var response = Console.ReadLine();
        Console.WriteLine($"{"ID",-5} {"Type",-10} {"Name",-20} {"Status",-15}");
        Console.WriteLine(new string('-', 50));
        foreach (var h in service.Hardwares)
        {
            if (string.IsNullOrWhiteSpace(response))
            {
                Console.WriteLine($"{h.Id,-5} {h.GetType().Name,-10} {h.Name,-20} {h.Status,-15}");
            }
            else if (int.TryParse(response, out int statusInt))
            {
                STATUS status = (STATUS)statusInt;
                if (h.Status == status)
                {
                    Console.WriteLine($"{h.Id,-5} {h.GetType().Name,-10} {h.Name,-20} {h.Status,-15}");
                }
            }
        }

        Console.WriteLine(new string('-', 50));
    }

    // ===== RENT =====
    public void RentHardware()
    {
        try
        {
            Console.Write("User ID: ");
            int userId = int.Parse(Console.ReadLine());

            Console.Write("Hardware ID: ");
            int hardwareId = int.Parse(Console.ReadLine());

            User user = service.Users.First(u => u.Id == userId);
            Hardware hardware = service.Hardwares.First(h => h.Id == hardwareId);

            service.RentHardwareToUser(hardware, user);

            Show("Successfully rented hardware: " + hardware.Name + " to " + user.Name);
        }
        catch (Exception e)
        {
            Show(e.Message);
        }
    }

    // ===== RETURN =====
    public void ReturnHardware()
    {
        try
        {
            Console.Write("User ID: ");
            int userId = int.Parse(Console.ReadLine());

            Console.Write("Hardware ID: ");
            int hardwareId = int.Parse(Console.ReadLine());

            var user = service.Users.First(u => u.Id == userId);
            var hardware = service.Hardwares.First(h => h.Id == hardwareId);

            double penalty = service.ReturnHardwareAndCalculatePenalty(hardware, user);

            Show($"Returned! Penalty: {penalty} zł");
        }
        catch (Exception e)
        {
            Show(e.Message);
        }
    }

    // ===== RENTALS =====
    public void ShowUserRentals()
    {
        try
        {
            Console.Write("User ID: ");
            int userId = int.Parse(Console.ReadLine());

            var user = service.Users.First(u => u.Id == userId);

            service.PrintUserRentals(user);
        }
        catch (Exception e)
        {
            Show(e.Message);
        }
    }

    public void ShowOverdue()
    {
        try
        {
            service.PrintOverdueRentals();
        }
        catch (Exception e)
        {
            Show(e.Message);
        }
    }
    public void ShowReport()
    {
        Console.WriteLine(service.GenerateReport());
    }

    // ===== MENU =====
    public void Run()
    {
        while (true)
        {
            Console.WriteLine("\n=== MENU ===");
            Console.WriteLine("1. Add user");
            Console.WriteLine("2. Show all hardware");
            Console.WriteLine("3. Rent hardware");
            Console.WriteLine("4. Return hardware");
            Console.WriteLine("5. Show user rentals");
            Console.WriteLine("6. Show overdue rentals");
            Console.WriteLine("7. Report");
            Console.WriteLine("0. Exit");

            Console.Write("Choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": AddUser(); break;
                case "2": ShowAllHardware(); break;
                case "3": RentHardware(); break;
                case "4": ReturnHardware(); break;
                case "5": ShowUserRentals(); break;
                case "6": ShowOverdue(); break;
                case "7": ShowReport(); break;
                case "0": return;
                default: Show("Invalid option!"); break;
            }
        }
    }
}
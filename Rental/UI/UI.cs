namespace Rental.UI;

using Logic;
using Users;

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
    public void ShowAllUsers()
    {
        Console.Write(service.GenerateShowAllUsers());
    }
    // ===== HARDWARE =====
    public void AddHardware()
    {
        try
        {
            Console.WriteLine("TYPE (0 = LAPTOP, 1 = CAMERA, 2 = PROJECTOR)");
            Console.Write("Choice: ");
            var response = Console.ReadLine();
            switch (response)
            {
                case "0":
                    Console.Write("Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Price: ");
                    double price = double.Parse(Console.ReadLine());

                    Console.Write("Processor (optional): ");
                    string processor = Console.ReadLine();

                    Console.Write("Graphics card (optional): ");
                    string graphics = Console.ReadLine();

                    Console.Write("RAM (GB): ");
                    int ram = int.Parse(Console.ReadLine());

                    Console.Write("Storage (GB): ");
                    int storage = int.Parse(Console.ReadLine());

                    Console.Write("Screen size (inches): ");
                    double screen = double.Parse(Console.ReadLine());

                    var laptop = new LaptopBuilder()
                        .WithName(name)
                        .WithPrice(price)
                        .WithProcessor(string.IsNullOrWhiteSpace(processor) ? null : processor)
                        .WithGraphicsCard(string.IsNullOrWhiteSpace(graphics) ? null : graphics)
                        .WithRAM(ram)
                        .WithStorage(storage)
                        .WithScreenSize(screen)
                        .Build();

                    service.AddHardware(laptop);

                    Show("Laptop added successfully!");
                    break;
                case "1":
                    Console.Write("Name: ");
                    string camName = Console.ReadLine();

                    Console.Write("Price: ");
                    double camPrice = double.Parse(Console.ReadLine());

                    Console.Write("Resolution (MP): ");
                    double resolution = double.Parse(Console.ReadLine());

                    Console.Write("Sensor type (optional): ");
                    string sensor = Console.ReadLine();

                    Console.Write("Lens mount (optional): ");
                    string lens = Console.ReadLine();

                    var camera = new CameraBuilder()
                        .WithName(camName)
                        .WithPrice(camPrice)
                        .WithResolution(resolution)
                        .WithSensorType(string.IsNullOrWhiteSpace(sensor) ? null : sensor)
                        .WithLensMount(string.IsNullOrWhiteSpace(lens) ? null : lens)
                        .Build();

                    service.AddHardware(camera);

                    Show("Camera added successfully!");
                    break;
                case "2":
                    Console.Write("Name: ");
                    string projName = Console.ReadLine();

                    Console.Write("Price: ");
                    double projPrice = double.Parse(Console.ReadLine());

                    Console.Write("Resolution (e.g. 1080p): ");
                    string projResolution = Console.ReadLine();

                    Console.Write("Brightness (ANSI lumens): ");
                    int brightness = int.Parse(Console.ReadLine());

                    Console.Write("Contrast ratio: ");
                    int contrast = int.Parse(Console.ReadLine());

                    var projector = new ProjectorBuilder()
                        .WithName(projName)
                        .WithPrice(projPrice)
                        .WithResolution(projResolution)
                        .WithBrightness(brightness)
                        .WithContrastRatio(contrast)
                        .Build();

                    service.AddHardware(projector);

                    Show("Projector added successfully!");
                    break;
            }
        }
        catch (Exception e)
        {
            Show(e.Message);
        }
    }
    public void ShowAllHardware()
    {
        Console.Write("Filter (ENTER = show all, 0 = AVAILABLE, 1 = RENTED, 2 = BROKEN, 3 = UNAVAILABLE): ");
        var response = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(response))
        {
            Console.Write(service.GenerateShowAllHardware());
        }
        else if (int.TryParse(response, out int statusInt))
        {
            Console.Write(service.GenerateShowAllHardware((STATUS)statusInt));
        }
    }
    public void ChangeStatusHardware()
    {
        try
        {
            Console.Write("Hardware ID: ");
            int hardwareId = int.Parse(Console.ReadLine());
            Hardware hardware = service.Hardwares.First(h => h.Id == hardwareId);
            Console.Write("Change status for: " + hardware.Name + " Status: " + hardware.Status); 
            Console.WriteLine("(0 = AVAILABLE, 1 = RENTED, 2 = BROKEN, 3 = UNAVAILABLE): ");
            var response = Console.ReadLine();
            if (int.TryParse(response, out int statusInt))
            {
                service.ChangeStatusForHardware(hardware, (STATUS)statusInt);
                Show("Hardware status changed to: " + hardware.Status);
            }
        }
        catch (Exception e)
        {
            Show(e.Message);
        }
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
            
            Console.Write("Days (optional, default week): ");
            var input = Console.ReadLine();

            int days = string.IsNullOrWhiteSpace(input) ? 7 : int.Parse(input);

            User user = service.Users.First(u => u.Id == userId);
            Hardware hardware = service.Hardwares.First(h => h.Id == hardwareId);
            
            service.RentHardwareToUser(hardware, user, days);

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

    public void InjectMockValues()
    {
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
        service.AddUser("Jan", "Kowalski", USR_TYPE.STUDENT);
        service.AddUser("Anna", "Nowak", USR_TYPE.EMPLOYEE);
        Show("Added mock values successfully!!!");
    }

    // ===== MENU =====
    public void Run()
    {
        while (true)
        {
            Console.WriteLine("\n=== MENU ===");
            Console.WriteLine("1. Add user");
            Console.WriteLine("2. Show users");  
            Console.WriteLine("3. Add hardware");
            Console.WriteLine("4. Show all hardware");
            Console.WriteLine("5. Rent hardware");
            Console.WriteLine("6. Return hardware");
            Console.WriteLine("7. Change Status of a Hardware");
            Console.WriteLine("8. Show user rentals");
            Console.WriteLine("9. Show overdue rentals");
            Console.WriteLine("10. Report");
            Console.WriteLine("d. Show Demo (Punkt 11-17)");
            Console.WriteLine("m. Inject Mock Values for debug");
            Console.WriteLine("0. Exit");

            Console.Write("Choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": AddUser(); break;
                case "2": ShowAllUsers(); break;
                case "3": AddHardware(); break;
                case "4": ShowAllHardware(); break;
                case "5": RentHardware(); break;
                case "6": ReturnHardware(); break;
                case "7": ChangeStatusHardware(); break;
                case "8": ShowUserRentals(); break;
                case "9": ShowOverdue(); break;
                case "10": ShowReport(); break;
                case "d": ShowcaseProgram.demo(); break;
                case "m": InjectMockValues(); break;
                case "0": return;
                default: Show("Invalid option!"); break;
            }
        }
    }
}
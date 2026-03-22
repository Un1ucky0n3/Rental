using Rental.Users;
using System;
using Rental.Exceptions;

namespace Rental.Logic;

public class Service
{
    private List<Hardware> Hardwares { get; set; } = new();
    private List<User> Users { get; set; } = new();
    private List<Rental> Rentals { get; set; } = new();

    public double defaultPenalty { get; set; } = 0.5; //zł

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

    public void RentHardwareToUser(Hardware hardware, User user, int days = 7)
    {
        try
        {
            DoExceptionChecksForUserHardwareInteractions(user, hardware, SCENARIO.RENT);
            hardware.Status = STATUS.UNAVAILABLE;
            Rentals.Add(
                    new Rental(hardware, user, 
                        DateTime.Today.ToString("d"), days, 
                        DateTime.Today.AddDays(days).ToString("d")));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    public double ReturnHardwareAndCalculatePenalty(Hardware hardware, User user, double? penalty = null)
    {
        penalty ??= defaultPenalty;
        try
        {
            DoExceptionChecksForUserHardwareInteractions(user, hardware, SCENARIO.RETURN);
            var rental = Rentals.FirstOrDefault(r =>
                r.User.Id == user.Id && r.Hardware.Id == hardware.Id);

            DateTime endDate = DateTime.Parse(rental.ActualReturnDate);
            DateTime today = DateTime.Today;

            double totalPenalty = 0;

            if (today > endDate)
            {
                int overdueDays = (today - endDate).Days;
                totalPenalty = overdueDays * penalty.Value;
            }

            Rentals.Remove(rental);
            hardware.Status = STATUS.AVAILABLE;

            return totalPenalty;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return 0;
        }
    }

    private enum SCENARIO
    {
        RENT,
        RETURN
    }
    private void DoExceptionChecksForUserHardwareInteractions(User user, Hardware hardware, SCENARIO scenario)
    {
        int amountOfRentalsByUser = 0;
        switch (scenario)
        {
            case SCENARIO.RENT:
                if(!hardware.Status.Equals(STATUS.AVAILABLE)) throw new ThisHardwareIsNotAvailableException(hardware);
                foreach (Rental r in Rentals)
                {
                    if (r.User.Id == user.Id)
                    {
                        amountOfRentalsByUser++;
                        if (r.Hardware.Id == hardware.Id) throw new UserAlreadyRentedOutThisHardwareException(user, hardware);
                    }
                    if (amountOfRentalsByUser >= user.MaxRental)
                    {
                        throw new UserRentedOutTooMuchHardwareException(user);
                    }
                }
                break;
            case SCENARIO.RETURN:
                bool exists = Rentals.Any(r =>
                    r.User.Id == user.Id && r.Hardware.Id == hardware.Id);

                if (!exists) throw new RentalNotFoundException(hardware, user);
                break;
        }
    }
    
    public void MarkHardwareAsUnavailable(Hardware hardware, STATUS status)
    {
        hardware.Status = status;
    }
    public void PrintUserRentals(User user)
    {
        var rentals = Rentals.Where(r => r.User.Id == user.Id);

        foreach (var r in rentals)
        {
            Console.WriteLine($"{r.Hardware.Name} | Due: {r.ActualReturnDate}");
        }
    }
    public void PrintOverdueRentals()
    {
        DateTime today = DateTime.Today;

        var overdue = Rentals.Where(r => DateTime.Parse(r.ActualReturnDate) < today);

        foreach (var r in overdue)
        {
            Console.WriteLine($"{r.Hardware.Name} rented by {r.User.Name} is overdue!");
        }
    }
    
    public void GenerateReport()
    {
        int total = Hardwares.Count;
        int available = Hardwares.Count(h => h.Status == STATUS.AVAILABLE);
        int rented = Rentals.Count;

        Console.WriteLine("=== REPORT ===");
        Console.WriteLine($"Total hardware: {total}");
        Console.WriteLine($"Available: {available}");
        Console.WriteLine($"Rented: {rented}");
    }
}
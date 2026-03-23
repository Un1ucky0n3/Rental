using Rental.Users;
using System;
using System.Text;
using Rental.Exceptions;

namespace Rental.Logic;

public class Service
{
    public List<Hardware> Hardwares { get; set; } = new();
    public List<User> Users { get; set; } = new();
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
    public void RentHardwareToUser(Hardware hardware, User user, int days = 7)
    {
        DoExceptionChecksForUserHardwareInteractions(user, hardware, SCENARIO.RENT);
        hardware.Status = STATUS.RENTED;
        Rentals.Add(
            new Rental(hardware, user, 
                DateTime.Today.ToString("d"), days, 
                DateTime.Today.AddDays(days).ToString("d")));
    }
    public double ReturnHardwareAndCalculatePenalty(Hardware hardware, User user, double? penalty = null)
    {
        penalty ??= defaultPenalty;
        DoExceptionChecksForUserHardwareInteractions(user, hardware, SCENARIO.RETURN);
        var rental = Rentals.FirstOrDefault(r => r.User.Id == user.Id && r.Hardware.Id == hardware.Id);

        DateTime endDate = DateTime.Parse(rental.ReturnDate);
        DateTime today = DateTime.Today;
        double totalPenalty = 0;

        if (today > endDate) { 
            int overdueDays = (today - endDate).Days; 
            totalPenalty = overdueDays * penalty.Value;
        }

        Rentals.Remove(rental);
        hardware.Status = STATUS.AVAILABLE;

        return totalPenalty;
    }
    private enum SCENARIO
    {
        RENT,
        RETURN,
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
    public void ChangeStatusForHardware(Hardware hardware, STATUS status)
    {
        hardware.Status = status;
    }
    public void PrintUserRentals(User user)
    {
        var rentals = Rentals.Where(r => r.User.Id == user.Id);

        foreach (var r in rentals)
        {
            Console.WriteLine($"{r.Hardware.Name} | Due: {r.ReturnDate}");
        }
    }
    public void PrintOverdueRentals()
    {
        DateTime today = DateTime.Today;

        var overdue = Rentals.Where(r => DateTime.Parse(r.ReturnDate) < today);

        foreach (var r in overdue)
        {
            Console.WriteLine($"{r.Hardware.Name} rented by {r.User.Name} is overdue!");
        }
    }
    public string GenerateReport()
    {
        var report = new System.Text.StringBuilder();

        report.AppendLine($"{"ID",-5} {"Type",-10} {"Name",-20} {"Status",-15}");
        report.AppendLine(new string('-', 50));

        foreach (var h in Hardwares)
        {
            report.AppendLine($"{h.Id,-5} {h.GetType().Name,-10} {h.Name,-20} {h.Status,-15}");
        }

        report.AppendLine(new string('-', 50));

        int total = Hardwares.Count;
        int available = Hardwares.Count(h => h.Status == STATUS.AVAILABLE);
        int rented = Rentals.Count;

        report.AppendLine($"Total hardware: {total}");
        report.AppendLine($"Available: {available}");
        report.AppendLine($"Rented: {rented}");

        return report.ToString();
    }
    public string GenerateShowAllHardware(STATUS status)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append($"{"ID",-5} {"Type",-10} {"Name",-20} {"Status",-15}").Append("\n");
        sb.Append(new string('-', 50)).Append("\n");
        foreach (var h in Hardwares)
        {
            if (h.Status == status)
            {
                sb.Append($"{h.Id,-5} {h.GetType().Name,-10} {h.Name,-20} {h.Status,-15}").Append("\n");
            }
        }

        sb.Append(new string('-', 50)).Append("\n");
        return sb.ToString();
    }
    public string GenerateShowAllHardware()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append($"{"ID",-5} {"Type",-10} {"Name",-20} {"Status",-15}").Append("\n");
        sb.Append(new string('-', 50)).Append("\n");
        foreach (var h in Hardwares)
        {
            sb.Append($"{h.Id,-5} {h.GetType().Name,-10} {h.Name,-20} {h.Status,-15}").Append("\n");
        }

        sb.Append(new string('-', 50)).Append("\n");
        return sb.ToString();
    }
    public string GenerateShowAllUsers()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append($"{"ID",-5} {"Name",-10} {"Surname",-10} {"ACC_TYPE",-10}").Append("\n");
        sb.Append(new string('-', 35)).Append("\n");
        foreach (var u in Users)
        {
            sb.Append($"{u.Id,-5} {u.Name,-10} {u.Surname,-10} {u.Type,-10}").Append("\n");
        }

        sb.Append(new string('-', 35)).Append("\n");
        return sb.ToString();
    }
    
    
}
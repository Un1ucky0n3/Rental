namespace Rental.Users;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public USR_TYPE Type { get; set; }
    public int MaxRental { get; set; }

    public User(int id, string name, string surname, USR_TYPE type)
    {
        this.Id = id;
        this.Name = name;
        this.Surname = surname;
        this.Type = type;
        setMaxRental();
    }
    private void setMaxRental()
    {
        switch (Type)
        {
            case USR_TYPE.STUDENT:
                this.MaxRental = 2;
                break;
            case USR_TYPE.EMPLOYEE:
                this.MaxRental = 5;
                break;
            default:
                this.MaxRental = 0;
                break;
        }
    }
}
namespace Rental.Users;

public class User
{
    public int id { get; set; }
    public string name { get; set; }
    public string surname { get; set; }
    public USR_TYPE type { get; set; }
    public int maxRental { get; set; }

    public User(int id, string name, string surname, USR_TYPE type)
    {
        this.id = id;
        this.name = name;
        this.surname = surname;
        this.type = type;
        setMaxRental();
    }
    private void setMaxRental()
    {
        switch (type)
        {
            case USR_TYPE.STUDENT:
                this.maxRental = 2;
                break;
            case USR_TYPE.EMPLOYEE:
                this.maxRental = 5;
                break;
            default:
                this.maxRental = 0;
                break;
        }
    }
}
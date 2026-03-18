namespace Rental.Users;

public class User
{
    private int id { get; set; }
    private string name { get; set; }
    private string surname { get; set; }
    private USR_TYPE type { get; set; }
    private int maxRental { get; set; }

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
            case USR_TYPE.USER:
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
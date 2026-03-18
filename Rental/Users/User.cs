namespace Rental.Users;

public class User
{
    private int id;
    private string name;
    private string surname;
    private USR_TYPE type;
    private int maxRental;

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

    public int getId()
    {
        return this.id;
    }
    public void setId(int id)
    {
        this.id = id;
    }

    public string getName()
    {
        return this.name;
    }
    public void setName(string name)
    {
        this.name = name;
    }

    public string getSurname()
    {
        return this.surname;
    }
    public void setSurname(string surname)
    {
        this.surname = surname;
    }

    public USR_TYPE getType()
    {
        return this.type;
    }
    public void setType(USR_TYPE type)
    {
        this.type = type;
    }
    
    public int getMaxRental()
    {
        return this.maxRental;
    }
    public void setMaxRental(int maxRental)
    {
        this.maxRental = maxRental;
    }
}
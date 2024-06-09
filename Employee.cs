public class Employee : IEmployee
{
    public int EmployeeID {get; set;}
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public int HourlyRate {get; set;}
    public int HoursWorked {get; set;}
    public string Department {get; set;}

    public Employee(int e_id, string fname, string lname, int hrrate, int hrworked, string dept)
    {
        EmployeeID = e_id;
        FirstName = fname;
        LastName = lname;
        HourlyRate = hrrate;
        HoursWorked = hrworked;
        Department = dept;
    }

    public int GetID()
    {
        return EmployeeID;
    }

    public string GetName()
    {
        return FirstName + " " + LastName;
    }

    public int GetPay()
    {
        return HoursWorked * HourlyRate;
    }

    public override string ToString()
    {
        return 
        "\nID: " + GetID() + "\n" +
        "Name: " + GetName() + "\n";
    }
}
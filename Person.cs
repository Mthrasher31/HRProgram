public class Person : Employee
{
    public int PersonID {get; set;}
    public string Address {get; set;}
    public string PhoneNum {get; set;}
    public string Email {get; set;}
    public string Type {get; set;}

    public Person(int e_id, string fname, string lname, string type, int hrrate, int hrworked, string dept, string address, string phonenum, string email)
        : base (e_id, fname, lname, hrrate, hrworked, dept)
    {
        PersonID = e_id;
        Address = address;
        PhoneNum = phonenum;
        Email = email;
        Type = type;
    }

    public override string ToString()
    {
        //This cleans the output in the event the outputted party is not an employee.
        if(Type != "Employee")
        {
            return base.ToString() + "Type: " + Type + "\n";
        }
        else
        {
            return base.ToString() + 
            "Dept: " + Department + "\n" +
            "Pay Amount: $" + GetPay() + "\n";
        }
    }
}
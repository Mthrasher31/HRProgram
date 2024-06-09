using System.Data.SQLite;

public class HRSoftware
{
    public static void Main(string[] args)
    {
        const string EDB = "EmployeeDatabase.db";
        SQLiteConnection conn = SQLiteDatabase.Connect(EDB);

        List<Person> people = new List<Person>{};
        
        Person p1 = new Person(1, "Michael", "Thrasher", "Employee", 18, 40, "R&D", "1234 Fake Address Lane", "423-223-1923", "micthr9989@students.ecpi.edu");
        people.Add(p1);
        Person p2 = new Person(2, "Joe", "Shmoe", "Client", 0, 0, "N/A", "4534 Burgundy Dr", "923-243-2943", "JoeSchmoe@gmail.com");
        people.Add(p2);
        Person p3 = new Person(3, "Alice", "Wonder", "Client", 0, 0, "N/A", "1234 Elm St", "555-123-4567", "alice@example.com");
        people.Add(p3);
        Person p4 = new Person(4, "Bob", "Builder", "Employee", 25, 40, "Security", "9876 Oak St", "555-234-5678", "bob@thebuilder.com");
        people.Add(p4);

        
        if (conn != null)
        {
            EmployeeDb.CreateTable(conn);

            foreach (var person in people)
            {
                if (person.Type == "Employee")
                {
                    EmployeeDb.AddEmployee(conn, person);
                }
            }
        }

        PrintAllEmployees(conn);
    }
    
    public static void PrintAllEmployees(SQLiteConnection conn)
    {
        List<Employee> employees = EmployeeDb.GetAllEmployees(conn);
        foreach (var employee in employees)
        {
            Console.WriteLine(employee);
        }
    }
}
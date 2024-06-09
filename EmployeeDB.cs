using System.Data.SQLite;

public class EmployeeDb
{
    public static void CreateTable(SQLiteConnection conn)
    {
        // SQL statement for creating a new table
        string sql =
        "CREATE TABLE IF NOT EXISTS Employees (\n"
        + " ID integer PRIMARY KEY\n"
        + " ,FirstName varchar(20)\n"
        + " ,LastName varchar(40)\n"
        + " ,HourlyRate integer\n"
        + " ,HoursWorked integer\n"
        + " ,Department varchar(20)\n"
        + ");";
        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }
    
    public static void AddEmployee(SQLiteConnection conn, Employee em)
    {
        string sql = string.Format(
        "INSERT INTO Employees(FirstName, LastName, HourlyRate, HoursWorked, Department) "
        + "VALUES('{0}','{1}',{2},{3},'{4}')",
        em.FirstName, em.LastName, em.HourlyRate, em.HoursWorked, em.Department);
        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }
    
    public static void UpdateEmployee(SQLiteConnection conn, Employee em)
    {
        string sql = string.Format(
        "UPDATE Employees SET FirstName='{0}', LastName='{1}', HourlyRate='{2}', HoursWorked'{3}', Department='{4}'"
        + " WHERE ID={5}", em.FirstName, em.LastName, em.HourlyRate, em.HoursWorked, em.Department, em.EmployeeID);
        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }
    
    public static void DeleteEmployee(SQLiteConnection conn, int EmployeeID)
    {
        string sql = string.Format("DELETE from Employees WHERE ID = {0}", EmployeeID);
        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }
    
    public static List<Employee> GetAllEmployees(SQLiteConnection conn)
    {
        List<Employee> employee = new List<Employee>();
        string sql = "SELECT * FROM Employees";
        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        SQLiteDataReader rdr = cmd.ExecuteReader();
        while (rdr.Read())
        {
            employee.Add(new Employee(
            rdr.GetInt32(0),
            rdr.GetString(1),
            rdr.GetString(2),
            rdr.GetInt32(3),
            rdr.GetInt32(4),
            rdr.GetString(5)
            ));
        }
        return employee;
    }
    
    public static Employee GetEmployee(SQLiteConnection conn, int EmployeeID)
    {
        string sql = string.Format("SELECT * FROM Employees WHERE ID = {0}", EmployeeID);
        SQLiteCommand cmd = conn.CreateCommand();
        cmd.CommandText = sql;
        SQLiteDataReader rdr = cmd.ExecuteReader();
        if (rdr.Read())
        {
            return new Employee(
            rdr.GetInt32(0),
            rdr.GetString(1),
            rdr.GetString(2),
            rdr.GetInt32(3),
            rdr.GetInt32(4),
            rdr.GetString(5)
            );
        }
        else
        {
            return new Employee(-1, string.Empty, string.Empty, -1, -1, string.Empty);
        }
    }
}
using System;
public static class Connector
{
    //public static string CONN_SQLServer { get; } = "Server=127.0.0.1;Database=TSQLFundamentals2008;User Id=sa;Password=SQL_server0%;";

    //public  static string CONN_SQLServer { get; }  = "Server=192.168.0.137;Database=NoNullProject;User Id=sa;Password=SQL_server0%;";

   public  static string CONN_SQLServer { get; }  = "Server=127.0.0.1;Database=NoNullProject;User Id=sa;Password=SQL_server0%;";
    public static string SELECT_ALL_EMPLOYEES { get; } = "SELECT * FROM HR.Employees";
    public static string SELECT_ALL_EMPLOYEES_LASTNAME_LIKE { get; } = "SELECT * FROM HR.Employees where lastname LIKE @chars";

    public static string INSERT_EMP = "INSERT INTO HR.Employees VALUES(@firstname,@lastname,@title,@titleofcourtesy,@birthdate,@hiredate,@address,@city,@region,@postalcode,@country,@phone,@mgrid)";

    public static string DELETE_EMPLOYEE_BY_ID = "DELETE FROM HR.Employees where empid = @id";

    public static string DELETE_ORDERS_BY_EMPID = "DELETE FROM Sales.Orders where empid = @id";

    public static string SELECT_BY_TITLE = "SELECT * FROM HR.Employees where title = @title";

    public static string SELECT_ALL_PROFESSIONIST = "SELECT * FROM NoNull.Professionists";

    public static string SELECT_ALL_PROFESSIONIST_LASTNAME_LIKE = "SELECT * FROM NoNull.Professionists where lastname LIKE @chars";


}
using day9_c__Assessment2;
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Enter the Deatils");
        Console.WriteLine("Enter the Employee Type (Permanent/Temporary):");
        string emptype = Console.ReadLine().ToLower();
        Console.WriteLine("Enter the Employee ID:");
        int id = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter the Employee Name:");
        string name = Console.ReadLine();
        if(emptype.ToLower() =="permanent")
        {
            PermanentEmployee peremp = new PermanentEmployee();
            Console.WriteLine("Enter the Basic Salary:");
            float basicsalary = Convert.ToSingle(Console.ReadLine());
            peremp.calculatesalary(id, name, basicsalary);
            Console.WriteLine("\nThe Deatails of this Permanent Employee are:");
            Console.WriteLine($"ID: {peremp.Id}");
            Console.WriteLine($"Name: {peremp.Name}");
            Console.WriteLine($"Basic Salary: {peremp.BasicSalary}");
            Console.WriteLine($"PF Amount: {peremp.Pf}");
            Console.WriteLine($"Bouns: {peremp.Bonus}");
            Console.WriteLine($"Net Salary: {peremp.NetSalary}");
        }
        else if(emptype.ToLower() == "temporary")
        {
            TemporaryEmployee tempemp = new TemporaryEmployee();
            tempemp.calculatesalary(id, name, 0);
            Console.WriteLine("\nThe Deatails of this Temporary Employee are:");
            Console.WriteLine($"ID: {tempemp.Id}");
            Console.WriteLine($"Name: {tempemp.Name}");
            Console.WriteLine($"Daily Wage: {tempemp.DailyWage}");
            Console.WriteLine($"Number of Days Worked: {tempemp.NoOfDays}");
            Console.WriteLine($"Bonus: {tempemp.Bonus}");
            Console.WriteLine($"Net Salary: {tempemp.NetSalary}");
        }
        else
        {
            Console.WriteLine("Invalid Employee Type");
        }
    }
}
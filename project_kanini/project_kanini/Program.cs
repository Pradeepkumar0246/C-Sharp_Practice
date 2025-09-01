internal class Program
{
    private static void Main(string[] args)
    {
        // 1st question

        //string num = Console.ReadLine();
        //int a= Convert.ToInt32(num);
        //int length = num.Length;
        //Console.WriteLine("First approach");
        //Console.WriteLine($"First Digit = {num[0]}");
        //Console.WriteLine($"Last Digit ={num[length-1]}");
        //Console.WriteLine("Second approach");
        //int fir = 0;
        //int sec = a % 10;
        //while (a > 0)
        //{
        //    fir = a % 10;
        //    a/=10;
        //}
        //Console.WriteLine("First Digit = " + fir);
        //Console.WriteLine("Last Digit = " + sec);

        // 2nd question

        //int n = Convert.ToInt32(Console.ReadLine());
        //if (n > 0)
        //{
        //    Console.WriteLine("The given number is Positive");
        //}
        //else if(n==0)
        //{
        //    Console.WriteLine("The given number is Zero");
        //}
        //else
        //{
        //    Console.WriteLine("The given number is Negative");
        //}

        // 3rd question

        //Console.WriteLine("Enter the number for which multiplication table to be displayed:");
        //int n = Convert.ToInt32(Console.ReadLine());
        //for (int i = 1; i <= 10; i++)
        //{
        //    Console.WriteLine($"{n} * {i} = {n * i}");
        //}

        // 4th question

        //Console.WriteLine("Enter the Basic Salary :");
        //int salary = Convert.ToInt32(Console.ReadLine());
        //double da = 0;
        //double hra = 0;
        //if (salary <= 10000)
        //{
        //    da= (salary * 80) / 100;
        //    hra = (salary * 20) / 100;
        //}
        //else if (salary>10000 && salary <20000)
        //{
        //    da = (salary * 90) / 100;
        //    hra = (salary * 25) / 100;
        //}
        //else if (salary > 20000)
        //{
        //    da = (salary * 95) / 100;
        //    hra = (salary * 30) / 100;           
        //}
        //Console.WriteLine("Gross Salary = " + (salary + da + hra));

        // 5th question
        Console.WriteLine("Enter the name:");
        String name = Console.ReadLine();
        Console.WriteLine("Enter the age:");
        int age = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter the id:");
        int id = Convert.ToInt32(Console.ReadLine());
        person obj1= new person(name, age, id);
        obj1.Eligibleornot();
    }
}
class person
{
    public string name;
    public int age;
    public int id;
    public person(string name, int age, int id)
    {
        this.name = name;
        this.age = age;
        this.id=id;
    }
    public void Eligibleornot()
    {
        if (age >= 18)
        {
            Console.WriteLine($"{name} with {id} is eligible for vote");
        }
        else
        {
            Console.WriteLine($"{name} with {id} is not eligible for vote");
        }
    }
}
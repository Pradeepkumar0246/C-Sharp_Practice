namespace day3_c_
{
    public class question1
    {
       public question1()
        {
            Console.WriteLine("Enter your name:");  
            string name=Console.ReadLine();
            Console.WriteLine("Enter your age:");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter your country:");
            string country = Console.ReadLine();
            Console.WriteLine($"Welcome {name}. Your age is {age} and you are from {country}.");
        }
    }
}

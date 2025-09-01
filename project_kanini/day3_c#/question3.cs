namespace day3_c_
{
    internal class question3
    {
        public question3()
        {
            Console.WriteLine("Enter a number x:");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter a number y:");
            int y = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("The result of whether x is greater than y is: " + (x > y?true:false));
        }
    }
}

namespace day3_c_
{
    internal class question5
    {
        public question5()
        {
            Console.WriteLine("Enter a number:");
            sbyte number = Convert.ToSByte(Console.ReadLine());
            if (number < 0)
            {
                Console.WriteLine("The given number is negative.");
            }
            else if (number > 0)
            {
                Console.WriteLine("The given number is positive.");
            }
            else
            {
                Console.WriteLine("The given number is zero.");
            }
            Console.WriteLine("The max value of signed byte is : "+ sbyte.MaxValue);
            Console.WriteLine("The min value of signed byte is : "+ sbyte.MinValue);
        }
    }
}

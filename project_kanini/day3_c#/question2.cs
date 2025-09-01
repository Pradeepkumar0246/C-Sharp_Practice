namespace day3_c_
{
    internal class question2
    {
        public question2()
        {
            Console.WriteLine("Enter a number:");
            int number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Square of the number is :"+ Math.Pow(number,2));
            Console.WriteLine("Cube of the number is :"+ Math.Pow(number,3));
        }
    }
}

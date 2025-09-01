namespace day4_c_
{
    internal class question1
    {
        public question1()
        {
            Console.WriteLine("Enter first name");
            string firstName = Console.ReadLine();

            Console.WriteLine("Enter last name");
            string lastName = Console.ReadLine();

            string fullName = firstName + " " + lastName;

            Console.WriteLine("Full name: " + fullName);
        }
    }
}

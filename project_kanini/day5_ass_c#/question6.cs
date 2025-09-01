namespace day5_ass_c_
{
    public interface IOpenable
    {
        string OpenSesame();
    }
    public class TreasureBox : IOpenable
    {
        public string OpenSesame()
        {
            return "Congratulations, Here is your lucky win";
        }
    }
    public class Parachute : IOpenable
    {
        public string OpenSesame()
        {
            return "Have a thrilling experience flying in air";
        }
    }
    internal class question6
    {
        public question6()
        {
            Console.WriteLine("Enter the letter found in the paper");
            string input = Console.ReadLine().Trim().ToUpper();

            IOpenable item;

            if (input == "T")
            {
                item = new TreasureBox();
            }
            else if (input == "P")
            {
                item = new Parachute();
            }
            else
            {
                Console.WriteLine("Invalid input.");
                return;
            }
            Console.WriteLine(item.OpenSesame());
        }
    }
}

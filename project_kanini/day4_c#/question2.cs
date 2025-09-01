
namespace day4_c_
{
    internal class question2
    {
        public question2()
        {
            Console.WriteLine("Enter a sentence:");
            string input = Console.ReadLine();
            string[] words = input.Split(' ');
            Array.Reverse(words);
            string reversedSentence = string.Join(" ", words);
            Console.WriteLine("Reversed sentence:");
            Console.WriteLine(reversedSentence);
        }
    }
}

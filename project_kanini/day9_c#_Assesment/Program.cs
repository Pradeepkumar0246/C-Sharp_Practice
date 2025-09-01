internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Enter The Word");
        string word = Console.ReadLine();
        string result = "";
        for(int i = 0; i < word.Length; i++)
        {
            char c= word[i];
            if (i%2==0)
            {
                result += char.ToUpper(c);
            }
            else
            {
                result += char.ToLower(c);
            }
        }
        Console.WriteLine("The Result is:");
        Console.WriteLine(result);
    }
}
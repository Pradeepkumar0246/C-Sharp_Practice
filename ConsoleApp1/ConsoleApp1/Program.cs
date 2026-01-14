internal class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Enter how many Fibonacci numbers to generate: ");
        int count = int.Parse(Console.ReadLine());

        List<int> series = GetFibonacciSeries(count);

        Console.WriteLine("Fibonacci Series:");
        foreach (var num in series)
        {
            Console.Write(num + " ");
        }
    }

    public static List<int> GetFibonacciSeries(int count)
    {
        var series = new List<int>();
        if (count <= 0) return series;

        series.Add(0);
        if (count == 1) return series;

        series.Add(1);
        for (int i = 2; i < count; i++)
        {
            int next = series[i - 1] + series[i - 2];
            series.Add(next);
        }

        return series;
    }
}
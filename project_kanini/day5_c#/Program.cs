internal class Program
{
    private static void Main(string[] args)
    {
        int[][] jag = new int[3][];
        jag[0] = new int[] { 1, 2, 3 };
        jag[1] = new int[] { 4, 5, 6, 7 };
        jag[2] = new int[] { 8, 9 };
        //for (int i = 0; i < jag.Length; i++)
        //{
        //    for (int j = 0; j < jag[i].Length; j++)
        //    {
        //        Console.Write(jag[i][j] + " ");
        //    }
        //    Console.WriteLine();
        //}
        Console.WriteLine("Enter the number of Teams :");
        int teams=Convert.ToInt32(Console.ReadLine());
        int[][] outar = new int[teams][];
        for (int i=0;i<outar.Length;i++)
        {
            Console.WriteLine("Enter the number of round played by team "+(i+1)+" :");
            int rounds = Convert.ToInt32(Console.ReadLine());
            outar[i] = new int[rounds];
            Console.WriteLine("Enter the scores for each round for team " + (i + 1) + " :");
            for (int j = 0; j < rounds; j++)
            {
                outar[i][j] = Convert.ToInt32(Console.ReadLine());
            }
        }
        for (int i = 0; i < outar.Length; i++)
        {
            Console.Write("Team " + (i + 1) + " scores: ");
            int sum = 0;
            for (int j = 0; j < outar[i].Length; j++)
            {
                Console.Write(outar[i][j] + " ");
                sum += outar[i][j];
            }
            Console.WriteLine("Total Score: " + sum);
            Console.WriteLine();
        }

    }
}
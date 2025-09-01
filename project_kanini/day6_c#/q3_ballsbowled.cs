namespace day6_c_
{
    class PlayerBO
    {
        private List<int> oversList = new List<int>();
        public void AddOversDetails(int oversBowled)
        {
            oversList.Add(oversBowled);
        }
        public int GetNoOfBallsBowled()
        {
            int totalBalls = 0;
            foreach (int overs in oversList)
            {
                totalBalls += overs * 6; 
            }
            return totalBalls;
        }
    }
    internal class q3_ballsbowled
    {
        public q3_ballsbowled()
        {
            PlayerBO player = new PlayerBO();

            Console.Write("Enter the number of overs: ");
            int overs = int.Parse(Console.ReadLine());

            player.AddOversDetails(overs);
            int ballsBowled = player.GetNoOfBallsBowled();

            Console.WriteLine($"Balls Bowled : {ballsBowled}");
        }
    }
}

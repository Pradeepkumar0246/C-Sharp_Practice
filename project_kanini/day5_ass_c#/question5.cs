namespace day5_ass_c_
{
    public class Game
    {
        public string Name { get; set; }
        public int MaxNumPlayers { get; set; }
        public override string ToString()
        {
            return $"Maximum number of players for {Name} is {MaxNumPlayers}";
        }
    }

    public class GameWithTimeLimit : Game
    {
        public int TimeLimit { get; set; }
        public override string ToString()
        {
            return base.ToString() + $" Time Limit for {Name} is {TimeLimit} minutes";
        }
    }
    public class question5
    {
        public question5()
        {
            Console.WriteLine("Enter a game");
            string game1Name = Console.ReadLine();
            Console.WriteLine("Enter the maximum number of players");
            int game1Players = Convert.ToInt32(Console.ReadLine());
            Game game1 = new Game
            {
                Name = game1Name,
                MaxNumPlayers = game1Players
            };
            Console.WriteLine("Enter a game that has time limit");
            string game2Name = Console.ReadLine();
            Console.WriteLine("Enter the maximum number of players");
            int game2Players = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the time limit in minutes");
            int timeLimit = Convert.ToInt32(Console.ReadLine());
            GameWithTimeLimit game2 = new GameWithTimeLimit
            {
                Name = game2Name,
                MaxNumPlayers = game2Players,
                TimeLimit = timeLimit
            };
            Console.WriteLine(game1.ToString());
            Console.WriteLine(game2.ToString());
        }
    }
}

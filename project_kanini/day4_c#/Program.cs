namespace day4_c_
{
    public class question3
    {
        private int id;
        private string accountType;
        private double balance;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string AccountType
        {
            get { return accountType; }
            set { accountType = value; }
        }
        public double Balance
        {
            get { return balance; }
            set { balance = value; }
        }
        public question3()
        {
            id = 0;
            accountType = "default";
            balance = 0.0;
        }
        public question3(int id, string accountType, double balance)
        {
            this.id = id;
            this.accountType = accountType;
            this.balance = balance;
        }
        public bool Withdraw(double amount)
        {
            if (amount <= balance)
            {
                balance -= amount;
                return true;
            }
            return false;
        }
        public string GetDetails()
        {
            return $"Account Id: {id}\nAccount Type: {accountType}\nBalance: {balance}";
        }
    }
    public class Program
    {
        static void Main()
        {
            //question1 q1 = new question1();
            //question2 q2 = new question2();
            Console.WriteLine("Enter account id");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter account type");
            string type = Console.ReadLine();
            Console.WriteLine("Enter account balance");
            double balance = double.Parse(Console.ReadLine());
            question3 acc = new question3(id, type, balance);
            Console.WriteLine(acc.GetDetails());
            Console.WriteLine("Enter amount to withdraw");
            double amount = double.Parse(Console.ReadLine());
            if (acc.Withdraw(amount))
            {
                Console.WriteLine($"New Balance: {acc.Balance}");
            }
        }
    }

}
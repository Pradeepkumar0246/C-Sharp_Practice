
namespace day5_ass_c_
{
    class Account
    {
        private string accountNumber;
        private decimal balance;
        private string ownerName;
        public Account(string accNumber, string owner)
        {
            accountNumber = accNumber;
            ownerName = owner;
            balance = 0;
        }
        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                balance += amount;
                Console.WriteLine($"Deposited: {amount:F2}");
            }
            else
            {
                Console.WriteLine("Invalid deposit amount.");
            }
        }
        public void Withdraw(decimal amount)
        {
            if (amount > 0 && amount <= balance)
            {
                balance -= amount;
                Console.WriteLine($"Withdrew: {amount:F2}");
            }
            else
            {
                Console.WriteLine("Invalid or insufficient balance for withdrawal.");
            }
        }
        public void DisplayBalance()
        {
            Console.WriteLine($"Account Balance: {balance:F2}");
        }
    }

    public class question4
    {
        public question4()
        {
            Console.Write("Enter account number: ");
            string accNumber = Console.ReadLine();
            Console.Write("Enter owner name: ");
            string owner = Console.ReadLine();
            Account myAccount = new Account(accNumber, owner);
            Console.Write("Enter amount to deposit: ");
            decimal depositAmount = Convert.ToDecimal(Console.ReadLine());
            myAccount.Deposit(depositAmount);
            myAccount.DisplayBalance();
            Console.Write("Enter amount to withdraw: ");
            decimal withdrawAmount = Convert.ToDecimal(Console.ReadLine());
            myAccount.Withdraw(withdrawAmount);
            myAccount.DisplayBalance();
        }
    }
}

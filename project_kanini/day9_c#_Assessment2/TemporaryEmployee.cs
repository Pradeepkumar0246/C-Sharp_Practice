
namespace day9_c__Assessment2
{
    internal class TemporaryEmployee: Employee
    {
        public int DailyWage;
        public int NoOfDays;
        public override float calculatesalary(int id, string name, float basicsalary)
        {
            this.Id = id;
            this.Name = name;
            Console.WriteLine("Enter the Daily Wage:");
            this.DailyWage = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Number of Days Worked:");
            this.NoOfDays = Convert.ToInt32(Console.ReadLine());
            this.NetSalary = this.DailyWage * this.NoOfDays;
            this.Bonus = calculatebonus(this.BasicSalary, this.NoOfDays);
            return this.NetSalary + this.Bonus;
        }
        public override float calculatebonus(float netsalary, int dailywages)
        {
            if (dailywages < 1000)
            {
                return netsalary * 0.15f;
            }
            else if (dailywages >= 1000 && dailywages < 1500)
            {
                return netsalary * 0.12f;
            }
            else if (dailywages >= 1500 && dailywages < 1750)
            {
                return netsalary * 0.11f;
            }
            else
            {
                return netsalary * 0.08f;
            }

        }
    }
}

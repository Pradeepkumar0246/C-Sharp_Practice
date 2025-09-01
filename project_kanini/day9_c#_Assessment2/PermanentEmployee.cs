
namespace day9_c__Assessment2
{
    internal class PermanentEmployee:Employee
    {
        public int Pf;
        public override float calculatesalary(int id, string name, float basicsalary)
        {
            this.Id = id;
            this.Name = name;
            this.BasicSalary = basicsalary;
            Console.WriteLine("Enter the PF Amount:");
            this.Pf = Convert.ToInt32(Console.ReadLine());
            this.NetSalary = this.BasicSalary - this.Pf;
            this.Bonus=calculatebonus(this.BasicSalary,this.Pf);
            return this.NetSalary + this.Bonus;
        }
        public override float calculatebonus(float BasicSalary, int Pf)
        {
            if (Pf < 1000)
            {
                return BasicSalary * 0.10f;
            }
            else if (Pf>=1000 && Pf<1500)
            {
                return BasicSalary * 0.115f;
            }
            else if (Pf >= 1500 && Pf < 1800)
            {
                return BasicSalary * 0.12f;
            }
            else
            {
                return BasicSalary * 0.15f;
            }
        }
    }
}

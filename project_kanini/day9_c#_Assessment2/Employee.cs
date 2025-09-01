
namespace day9_c__Assessment2
{
    internal abstract class Employee
    {
        public int Id;
        public string Name;
        public float BasicSalary;
        public float Bonus;
        public float NetSalary;
        public abstract float calculatesalary(int id,string name,float basicsalary);
        public abstract float calculatebonus(float value,int criteria);
    }
}

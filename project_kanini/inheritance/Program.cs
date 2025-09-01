class dept
{
    public int deptId;
    public dept(int id)
    {
        this.deptId = id;
    }
    public virtual void show()
    {
        Console.WriteLine("dept id: " + deptId);
    }
}
class emp : dept
{
    public string empName;
    public emp(int id, string name) :base(id)
    {
        this.empName = name;
    }
    public override void show()
    {
        base.show();
        Console.WriteLine("emp name: " + empName);
    }
}
class mana : emp
{
    public string manaLevel;
    public mana(int id, string name, string level) : base(id,name)
    {
        this.manaLevel = level;
    }
    public override void show()
    {
        base.show();
        Console.WriteLine("mana: " + manaLevel);
    }
}
class fulltime_emp : emp
{
    public int salary;
    public fulltime_emp(int id, string name, int salary) : base(id, name)
    {
        this.salary = salary;
    }
    public override void show()
    {
        base.show();
        Console.WriteLine("salary: " + salary);
    }
}
class parttime_emp : emp
{
    public int sal;
    public parttime_emp(int id, string name, int salary) : base(id, name)
    {
        this.sal = salary;
    }
    public override void show()
    {
        base.show();
        Console.WriteLine("Salary : " + sal);
    }
}
class intern_emp : emp
{
    public int stipend;
    public intern_emp(int id, string name, int stipend) : base(id, name)
    {
        this.stipend = stipend;
    }
    public override void show()
    {
        base.show();
        Console.WriteLine("Stipend: " + stipend);
    }
}
public class Program
{
    static void Main()
    {
        //mana m = new mana(Convert.ToInt32(Console.ReadLine()), Console.ReadLine(),Console.ReadLine());
        //mana n = new mana(Convert.ToInt32(Console.ReadLine()), Console.ReadLine(), Console.ReadLine());
        //m.show();
        //n.show();
        fulltime_emp f = new fulltime_emp(Convert.ToInt32(Console.ReadLine()), Console.ReadLine(), Convert.ToInt32(Console.ReadLine()));
        parttime_emp p = new parttime_emp(Convert.ToInt32(Console.ReadLine()), Console.ReadLine(), Convert.ToInt32(Console.ReadLine()));
        intern_emp i = new intern_emp(Convert.ToInt32(Console.ReadLine()), Console.ReadLine(), Convert.ToInt32(Console.ReadLine()));
        f.show();
        p.show();
        i.show();        
    }
}

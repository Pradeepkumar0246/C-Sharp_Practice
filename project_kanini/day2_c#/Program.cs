internal class Program
{
    private static void Main(string[] args)
    {
        int om=Convert.ToInt32(Console.ReadLine());
        int bm=0;
        string grade;
        Console.WriteLine("The mark and grade of this student is:");
        Console.WriteLine(am(om, ref bm, out grade));
        Console.WriteLine("grade : "+grade+" bm : "+bm);
    }
    static int am(int om,ref int bm,out String grade)
    {
        bm = om + 10;
        if(bm>90)
        {
            grade = "A+";
        }
        else if (bm >= 80 && bm <= 90)
        {
            grade = "A";
        }
        else if (bm >= 70 && bm < 80)
        {
            grade = "B+";
        }
        else if (bm >= 60 && bm < 70)
        {
            grade = "B";
        }
        else if (bm >= 50 && bm < 60)
        {
            grade = "C";
        }
        else
        {
            grade = "D";
        }
        return om;
    }
}
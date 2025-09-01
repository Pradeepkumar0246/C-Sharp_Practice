namespace day5_ass_c_
{
    class Student
    {
        public string Name;
        public int Age;
        public string Grade;

        public Student(string name, int age, string grade)
        {
            Name = name;
            Age = age;
            Grade = grade;
        }

        public void DisplayInfo()
        {
            Console.WriteLine("Student Name: " + Name);
            Console.WriteLine("Student Age: " + Age);
            Console.WriteLine("Student Grade: " + Grade);
        }
    }
    public class question2
    {
        public question2()
        {
            Console.WriteLine("Enter student's name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter student's age:");
            int age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter student's grade:");
            string grade = Console.ReadLine();

            Student student = new Student(name, age, grade);
            student.DisplayInfo();
        }
    }
}

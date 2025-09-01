namespace day5_ass_c_
{
    class Vehicle
    {
        public string Make;
        public string Model;
        public int Year;
        public Vehicle(string make, string model, int year)
        {
            Make = make;
            Model = model;
            Year = year;
        }

        public virtual void GetInfo()
        {
            Console.WriteLine($"{Year} {Make} {Model}");
        }
    }
    class Car : Vehicle
    {
        public Car(string make, string model, int year) : base(make, model, year) { }

        public override void GetInfo()
        {
            Console.WriteLine($"Car: {Year} {Make} {Model}");
        }
    }
    class Motorcycle : Vehicle
    {
        public Motorcycle(string make, string model, int year) : base(make, model, year) { }

        public override void GetInfo()
        {
            Console.WriteLine($"Motorcycle: {Year} {Make} {Model}");
        }
    }
    internal class question1
    {
        public question1()
        {
            Console.WriteLine("Enter car make:");
            string carMake = Console.ReadLine();

            Console.WriteLine("Enter car model:");
            string carModel = Console.ReadLine();

            Console.WriteLine("Enter car year:");
            int carYear = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter motorcycle make:");
            string motoMake = Console.ReadLine();

            Console.WriteLine("Enter motorcycle model:");
            string motoModel = Console.ReadLine();

            Console.WriteLine("Enter motorcycle year:");
            int motoYear = Convert.ToInt32(Console.ReadLine());

            Car myCar = new Car(carMake, carModel, carYear);
            Motorcycle myMoto = new Motorcycle(motoMake, motoModel, motoYear);

            myCar.GetInfo();
            myMoto.GetInfo();
        }
    }
}

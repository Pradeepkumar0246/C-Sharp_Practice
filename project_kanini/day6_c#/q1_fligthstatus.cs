namespace day6_c_
{
    public class q1_fligthstatus
    {
        static Dictionary<string, TimeSpan> fdt = new Dictionary<string, TimeSpan>()
        {
            {"DL4819", new TimeSpan(14,30,0) },
            {"AA5342", new TimeSpan(11,15,0) },
            {"BA5390", new TimeSpan(15,40,0) },
            {"UA811", new TimeSpan(18,45,0) },
            {"AI171", new TimeSpan(10,0,0) }
        };
        public static string fs(string flightno)
        {
            if (!fdt.ContainsKey(flightno))
            {
                return "Flight not found";
            }
            TimeSpan dt = fdt[flightno];
            TimeSpan ct = DateTime.Now.TimeOfDay;
            if (ct>=dt)
            {
                return "Flight has Already left Air port";
            }
            else
            {                
                TimeSpan timeLeft = dt - ct;
                return $"Time Left for the Flight {timeLeft.ToString(@"hh\:mm\:ss\.ffffff")}";
            }
        }
        public q1_fligthstatus()
        {
            Console.WriteLine("Flight Status Checker");
            Console.WriteLine("Available Flights:");
            foreach (var flight in fdt)
            {
                Console.WriteLine($"{flight.Key} - Departure Time: {flight.Value.ToString(@"hh\:mm\:ss")}");
            }
            Console.WriteLine("Enter Flight Number:");
            string flightno = Console.ReadLine().ToUpper();
            String flightStatus = fs(flightno);
            Console.WriteLine("Flight Status: " + flightStatus);
        }
    }
}

using System.Collections;

namespace day6_c_
{
    class Product
    {
        public string Name;
        public string Serial;
        public string PurchaseDate;
        public double Cost;

        public Product(string name, string serial, string date, double cost)
        {
            Name = name;
            Serial = serial;
            PurchaseDate = date;
            Cost = cost;
        }

        public void Display()
        {
            Console.WriteLine($"{Name,-15}{Serial,-15}{PurchaseDate,-15}{Cost,-15}");
        }
    }
    internal class q2_productdeatils
    {
        public q2_productdeatils()
        {
            ArrayList products = new ArrayList();
            products.Add(new Product("HairTrimmer", "HT123", "10-02-2017", 800));
            products.Add(new Product("Steel Box", "SB231", "11-04-2018", 250));
            products.Add(new Product("Rope", "RP240", "13-05-2019", 100));
            Console.WriteLine("{0,-15}{1,-15}{2,-15}{3,-15}","Product Name", "Serial", "Purchase Date", "Cost");
            Console.WriteLine("---------------------------------------------");
            foreach (Product p in products)
            {
                p.Display();
            }
        }
    }
}

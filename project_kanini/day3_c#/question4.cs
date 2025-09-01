namespace day3_c_
{
    internal class question4
    {
        public question4()
        {
            int pizzaPrice = 200;
            int puffPrice = 40;
            int pepsiPrice = 120;
            int gstpercentage = 12; 
            int cesspercentage = 5; 
            Console.WriteLine("Enter a number of pizzas bougth:");
            int pizzas = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the number of puffs bought:");
            int puffs = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the number of pepsi bought:");
            int pepsi = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Bill details:");
            int totalBill = (pizzas * pizzaPrice) + (puffs * puffPrice) + (pepsi * pepsiPrice);
            int gstAmount = (totalBill * gstpercentage) / 100;
            int cessAmount = (totalBill * cesspercentage) / 100;
            int finalBill = totalBill + gstAmount + cessAmount;
            Console.WriteLine("Cost of pizzas: " + (pizzas * pizzaPrice));
            Console.WriteLine("Cost of puffs: " + (puffs * puffPrice));
            Console.WriteLine("Cost of pepsi: " + (pepsi * pepsiPrice));
            Console.WriteLine("Total bill before tax: " + totalBill);
            Console.WriteLine("GST (12%): " + gstAmount);
            Console.WriteLine("Cess (5%): " + cessAmount);
            Console.WriteLine("Final bill after tax: " + finalBill);
        }
    }
}

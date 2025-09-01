namespace EFcoreexample1.Models
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            KaniniContext sam = new KaniniContext();
            foreach (Product samp in sam.Products)
            {
                Console.WriteLine($"Product ID: {samp.ProductId}, Name: {samp.ProductName}, Price: {samp.Price}, Quantity: {samp.Quantity}");
            }
            Console.WriteLine("Enter Values to add:");
            Product product = new Product();
            Console.Write("Product Name: ");
            product.ProductName = Console.ReadLine();
            Console.Write("Price: ");
            product.Price = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Quantity: ");
            product.Quantity = Convert.ToInt32(Console.ReadLine());
            sam.Products.Add(product);
            sam.SaveChanges();
            Console.WriteLine("Product added successfully!");
        }
    }
}
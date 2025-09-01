namespace day5_ass_c_
{
    struct Product
    {
        public string Name;
        public decimal Price;
        public int Quantity;
    }
    public class question3
    {
        public question3()
        {
            Product[] inventory = new Product[100]; 
            int count = 0; 

            while (true)
            {
                Console.WriteLine("\n1. Add Product");
                Console.WriteLine("2. View Products");
                Console.WriteLine("3. Update Product");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        if (count < inventory.Length)
                        {
                            Console.Write("Enter product name: ");
                            string name = Console.ReadLine();

                            Console.Write("Enter product price: ");
                            decimal price = Convert.ToDecimal(Console.ReadLine());

                            Console.Write("Enter product quantity: ");
                            int quantity = Convert.ToInt32(Console.ReadLine());

                            inventory[count].Name = name;
                            inventory[count].Price = price;
                            inventory[count].Quantity = quantity;

                            count++;
                            Console.WriteLine("Product added successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Inventory is full!");
                        }
                        break;

                    case 2:
                        for (int i = 0; i < count; i++)
                        {
                            Console.WriteLine($"Name: {inventory[i].Name}, Price: {inventory[i].Price}, Quantity: {inventory[i].Quantity}");
                        }
                        if (count == 0)
                        {
                            Console.WriteLine("No products in inventory.");
                        }
                        break;

                    case 3:
                        Console.Write("Enter product name to update: ");
                        string updateName = Console.ReadLine();
                        bool found = false;

                        for (int i = 0; i < count; i++)
                        {
                            if (inventory[i].Name.Equals(updateName, StringComparison.OrdinalIgnoreCase))
                            {
                                Console.Write("Enter new price: ");
                                inventory[i].Price = Convert.ToDecimal(Console.ReadLine());

                                Console.Write("Enter new quantity: ");
                                inventory[i].Quantity = Convert.ToInt32(Console.ReadLine());

                                Console.WriteLine("Product updated successfully!");
                                found = true;
                                break;
                            }
                        }
                        if (!found)
                        {
                            Console.WriteLine("Product not found.");
                        }
                        break;

                    case 4:
                        Console.WriteLine("Exiting...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
        }
    }
}

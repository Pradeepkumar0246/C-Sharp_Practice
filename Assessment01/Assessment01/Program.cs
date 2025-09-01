using System;
using Assessment01.Models;
using Assessment01.Repositories;
using System.Collections.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        string connectionString = "server=DESKTOP-BE5N6B8;Database=ProductInventory;Integrated Security=True";
        var piRepository = new PiRepository(connectionString);
        int i = 0;
        while (i ==0)
        {
            Console.WriteLine("Welcome to Product Inventory Management System");
            Console.WriteLine("1. Get All Products");
            Console.WriteLine("2. Insert New Product");
            Console.WriteLine("3. Get Product By Id");
            Console.WriteLine("4. Update Product");
            Console.WriteLine("5. Delete Product");
            // Example: Get all records
            if (i == 1) {
                List<pi> allPi = piRepository.GetAllPi();
                Console.WriteLine("All Products:");
                foreach (var item in allPi)
                {
                    Console.WriteLine($"Id: {item.piId}, Name: {item.piName}, Quantity: {item.piQuantity}, Price: {item.piprice}");
                }
            }
            
            if (i == 2)
            {
                // Example: Insert a new record
                Console.WriteLine("Enter product details to insert:");
                int piId = Convert.ToInt32(Console.ReadLine());
                string piName = Console.ReadLine();
                int piQuantity = Convert.ToInt32(Console.ReadLine());
                decimal piprice = Convert.ToDecimal(Console.ReadLine());
                var newPi = new pi
                {
                    piId = piId,
                    piName = piName,
                    piQuantity = piQuantity,
                    piprice = piprice
                };
                piRepository.InsertPi(newPi);

                Console.WriteLine($"Product {newPi.piName} inserted successfully.");
            }
            if (i == 3)
            {
                // Example: Get by Id
                Console.WriteLine("Enter Id to search the product..");
                int idToSearch = Convert.ToInt32(Console.ReadLine());
                var singlePi = piRepository.GetPiById(idToSearch);
                if (singlePi != null)
                {
                    Console.WriteLine($"Found: {singlePi.piName}");
                }
            }
                if (i == 4) {
                // Example: Update
                var newPi = new pi { };
                Console.WriteLine("Enter Id to update the product..");
                    newPi.piId = Convert.ToInt32(Console.ReadLine());
                    newPi.piName = Console.ReadLine();
                    newPi.piQuantity = Convert.ToInt32(Console.ReadLine());
                    newPi.piprice = Convert.ToDecimal(Console.ReadLine());
                    piRepository.UpdatePi(newPi);
                    Console.WriteLine($"Product with Id {newPi.piId} updated successfully.");
                }
            
            if (i == 5) {
                // Example: Delete
                Console.WriteLine("Enter Id to delete the product..");
                int idToDelete = Convert.ToInt32(Console.ReadLine());
                piRepository.DeletePi(idToDelete);
                Console.WriteLine($"Product with Id {idToDelete} deleted successfully.");

            }
            //// Example: Count
            int count = piRepository.Countpi();
            Console.WriteLine($"Total Products: {count}");

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            Console.WriteLine("Enter 0 to continue or 1 to exit");
            int n=Convert.ToInt32(Console.ReadLine());
            i = n;
        }
    }
}
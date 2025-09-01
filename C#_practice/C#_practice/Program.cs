using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Generic List example
        List<string> fruits = new List<string>();
        fruits.Add("Apple");
        fruits.Add("Banana");
        fruits.Add("Mango");

        Console.WriteLine("Fruits in the list:");
        foreach (string fruit in fruits)
        {
            Console.WriteLine(fruit);
        }

        // Generic Dictionary example
        Dictionary<int, string> students = new Dictionary<int, string>();
        students.Add(1, "Pradeep");
        students.Add(2, "Kumar");

        Console.WriteLine("\nStudent dictionary:");
        foreach (var kvp in students)
        {
            Console.WriteLine($"ID: {kvp.Key}, Name: {kvp.Value}");
        }
    }
}

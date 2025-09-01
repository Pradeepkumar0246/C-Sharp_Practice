using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Security.Principal;
internal class program
{
    private static void Main(string[] args)
    {
        account acc = new account()
        {
            Id = 1,
            Name = "pradeep",
            Balance = 1000.50
        };
        string jsonString = JsonConvert.SerializeObject(acc);
        FileStream fileStream = new FileStream("account.json", FileMode.OpenOrCreate);
        Console.WriteLine("Serialized JSON string:");
        Console.WriteLine(jsonString);
    }
}
class account
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Balance { get; set; }

    // Serialize the account object to a JSON string

}


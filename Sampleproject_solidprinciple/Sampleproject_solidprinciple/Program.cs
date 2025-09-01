using Sampleproject_solidprinciple.Interfaces;
using Sampleproject_solidprinciple.Models;
using Sampleproject_solidprinciple.Services;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var handlers = new List<IOrderTypeHandler>
        {
            new OnlineOrderHandler(),
            new StoreOrderHandler()
        };

        IOrderRepository repository = new OrderRepository();
        IEmailService emailService = new EmailService();

        var processor = new OrderProcessor(handlers, repository, emailService);

        var order = new Order
        {
            ProductType = "Store",
            Amount = 150.0
        };

        processor.ProcessOrder(order);
    }
}

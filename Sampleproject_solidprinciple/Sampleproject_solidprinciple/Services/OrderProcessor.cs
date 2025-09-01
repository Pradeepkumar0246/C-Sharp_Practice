using Sampleproject_solidprinciple.Interfaces;
using Sampleproject_solidprinciple.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sampleproject_solidprinciple.Services
{
    internal class OrderProcessor
    {
        private readonly List<IOrderTypeHandler> _handlers;
        private readonly IOrderRepository _repository;
        private readonly IEmailService _emailService;

        public OrderProcessor(List<IOrderTypeHandler> handlers, IOrderRepository repository, IEmailService emailService)
        {
            _handlers = handlers;
            _repository = repository;
            _emailService = emailService;
        }

        public void ProcessOrder(Order order)
        {
            Console.WriteLine("Order processing started...");

            var handler = _handlers.Find(h => h.CanHandle(order.ProductType));
            if (handler != null)
            {
                handler.Handle(order);
            }
            else
            {
                Console.WriteLine("Unknown product type.");
                return;
            }

            _repository.Save(order);
            _emailService.SendConfirmation(order);
        }
    }
}

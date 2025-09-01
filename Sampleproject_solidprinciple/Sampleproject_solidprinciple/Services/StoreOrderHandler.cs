using Sampleproject_solidprinciple.Interfaces;
using Sampleproject_solidprinciple.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sampleproject_solidprinciple.Services
{
    internal class StoreOrderHandler : IOrderTypeHandler
    {
        public bool CanHandle(string productType) => productType == "Store";

        public void Handle(Order order)
        {
            Console.WriteLine("Store order placed.");
        }
    }
}

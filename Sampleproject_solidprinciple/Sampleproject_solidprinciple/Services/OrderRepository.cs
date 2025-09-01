using Sampleproject_solidprinciple.Interfaces;
using Sampleproject_solidprinciple.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sampleproject_solidprinciple.Services
{
    internal class OrderRepository : IOrderRepository
    {
        public void Save(Order order)
        {
            Console.WriteLine("Order saved to database.");
        }
    }
}

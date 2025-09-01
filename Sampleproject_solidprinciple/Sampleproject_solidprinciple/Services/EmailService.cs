using Sampleproject_solidprinciple.Interfaces;
using Sampleproject_solidprinciple.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sampleproject_solidprinciple.Services
{
    internal class EmailService : IEmailService
    {
        public void SendConfirmation(Order order)
        {
            Console.WriteLine("Email sent to customer.");
        }
    }
}

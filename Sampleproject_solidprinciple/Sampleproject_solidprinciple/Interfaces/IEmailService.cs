using Sampleproject_solidprinciple.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sampleproject_solidprinciple.Interfaces
{
    public interface IEmailService
    {
        void SendConfirmation(Order order);
    }
}

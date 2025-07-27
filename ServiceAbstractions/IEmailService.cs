using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstractions
{
    public interface IEmailService
    {
        Task SendOrderStatusChangedEmailAsync(string toEmail, string newStatus);
    }
}

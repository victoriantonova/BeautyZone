using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyZone.SL.Interfaces
{
    public interface IEmailService
    {
        void SendEmailAsync(string email, string message);
    }
}

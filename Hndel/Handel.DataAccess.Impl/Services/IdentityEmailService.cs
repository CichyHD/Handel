using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Handel.Core.Contracts;
using Microsoft.AspNet.Identity;

namespace Handel.DataAccess.Impl.Services
{
    public class IdentityEmailService : IIdentityMessageService
    {
        private readonly IEmailService _emailService;

        public IdentityEmailService(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public Task SendAsync(IdentityMessage message)
        {
            return sendEmail(message);
        }

        private Task sendEmail(IdentityMessage message)
        {
            var emailSettings = new EmailSettings(message.Destination, message.Subject, message.Body);
            _emailService.SendEmail(emailSettings);
            return Task.FromResult(0);
        }
    }
}
